<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AGTSearchLvl.aspx.cs" Inherits="INSCL.AGTSearchLvl"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <style type="text/css">
        .panel-success {
            margin-left: 2% !important;
            margin-right: 2% !important;
        }

        .disablepage {
            display: none;
        }

        .gridview th {
    padding: 10px;
    height: 40px;
    border-color: #53accd !important;
    /*text-align: center;*/
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
} 
.clsCenter{
    text-align:center !important;
}
.clsLeft{
    text-align:left !important;
}

        .pad2 {
            padding-left: 03px;
            padding-right: 03px;
            display: none;
            /*Added by Raj for Modal popup start*/
            /*Added by Raj for Modal popup End*/
        }
    </style>


    <script type="text/javascript">
        $(function () {
            $("[id*=lnkView]").click(function () {
                var rowIndex = $(this).closest("tr")[0].rowIndex;
                window.open("Popup.aspx?rowIndex=" + rowIndex, "Popup", "width=350,height=100");
            });
        });
    </script>


    <script type="text/javascript">
        function popup() {
            $("#myModal").modal();
        }

        function Enable() {
            document.getElementById('ctl00_ContentPlaceHolder1_Div1').style.display = "none";
            document.getElementById('ctl00_ContentPlaceHolder1_Loading_gif').style.display = "block";
        }

        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
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

        function funPopUp(id) {
            debugger;
            //var start = document.getElementById("ctl00_ContentPlaceHolder1_lblChannel");
            //var value = start.textContent;
            //var Header = "Version History Of Channel";
            //var Flag = "CHANNEL";
            //alert(id)
            var strid = id;
            var bizscr = strid.replace("lnkAddMemType", "lblbizsrc");
            var memtyp = strid.replace("lnkAddMemType", "lblmemtyp");
            var chncls = strid.replace("lnkAddMemType", "lblchncls");


            //alert(document.getElementById(bizscr).innerText);

            document.getElementById('mdlViewBIDLOB')
            var BizsrcVal = document.getElementById(bizscr).innerText;
            var ChnClsVal = document.getElementById(chncls).innerText;
            var AgentTypeVal = document.getElementById(memtyp).innerText;

            //var abc = $("[id*=mdlViewBIDLOB]").attr("id");
            $find("mdlViewBIDLOB").show()

            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopViewPageNew.aspx?&mdlpopup=mdlViewBIDLOB" + "&Bizsrc=" + BizsrcVal + "&ChnCls=" + ChnClsVal + "&AgentType=" + AgentTypeVal;

            //document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=MdlPopExtndrLOB" + "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&Bizsrc=" + Bizsrc + "&ChnType=" + Chntype + "&ChnName=" + ChnName + "&MemTypeDesc=" + MemTypeDesc;
        }

<%--           function funPopUpNew() {
            debugger;
            //var start = document.getElementById("ctl00_ContentPlaceHolder1_lblChannel");
            //var value = start.textContent;
            //var Header = "Version History Of Channel";
            //var Flag = "CHANNEL";
            document.getElementById('mdlViewBIDLOB')
            var Bizsrc = document.getElementById('<%= hdngvbizsrc.ClientID%>').value;
            var ChnCls = document.getElementById('<%= hdngvchncls.ClientID%>').value;
            var AgentType = document.getElementById('<%= hdngvmemtype.ClientID%>').value;

            var abc = $("[id*=mdlViewBIDLOB]").attr("id");
            $find("mdlViewBIDLOB").show()

            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopViewPageNew.aspx?&mdlpopup=mdlViewBIDLOB" + "&Bizsrc=" + Bizsrc +"&ChnCls="+ ChnCls + "&AgentType"+AgentType;
        }--%>
        //document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=MdlPopExtndrLOB" 
        //+ "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&Bizsrc=" + Bizsrc + "&ChnType=" + Chntype + "&ChnName=" + ChnName + "&MemTypeDesc=" + MemTypeDesc;

        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();

        });



    </script>
    <%--Added by Pranjali on 28-05-2013 for modal popup display start--%>
    <asp:ScriptManager ID="SM1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>
    <%--Added by Pranjali on 28-05-2013 for modal popup display end--%>

    <%--Modal popup Setup Div  Added by Raj for ADD Below Mem Type--%>
    <asp:Panel runat="server" ID="PnlPopupLOB" Width="100%" Height="100%" display="none">
        <iframe runat="server" id="IframeLOB" width="100%" frameborder="0" style="height: 100%;"></iframe>

        <div>Raj</div>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDLOB"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--------Added by Raj from AGTLevel page-----------%>
    <asp:Panel runat="server" ID="pnlview" Width="800px" Height="400px" display="none" Style="display: none">
        <iframe runat="server" id="Iframe1" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>

    <asp:Label runat="server" ID="Label7" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupview" BehaviorID="ModalPopupviewBID"
        DropShadow="false" TargetControlID="Label7" PopupControlID="pnlview" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>


    <%--            <asp:Label runat="server" ID="Label7" Style="display: none" />


    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupview" BehaviorID="ModalPopupviewBID"
        DropShadow="false" TargetControlID="Label7" PopupControlID="pnlview" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>--%>


    <%--------Added by Raj from AGTLevel page-----------%>

    <%--<center  >--%>
                
         <div class="card PanelInsideTab" id="divMemTypehdrcollapse" runat="server" >
                  <div id="Div3" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divMemTypehdr','btndivMemTypehdr');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblAgtTypeSearch" runat="server"  CssClass="control-label HeaderColor"  Font-Size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                     <asp:LinkButton align="right" ID="lbOldHier" OnClick="btnOldHier_Click" Font-Bold="true" ForeColor="Yellow"  Font-Italic="true" Visible="false" Font-Size="Smaller" Text="View Old Hierarchy" runat="server" />
                         <span id="btndivMemTypehdr" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                  
                    <div id="divMemTypehdr" runat="server" class="panel-body" style="display:block"> 
                     <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblChnlType" runat="server" CssClass="control-label"></asp:Label>
                     </div>
                      <div class="col-md-3">
                            <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" CellPadding="2" 
                                                CellSpacing="2" RepeatDirection="Horizontal" 
                                        TabIndex="1" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="&nbsp;Company  &nbsp;&nbsp;"></asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1" Text="&nbsp;Channel"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                    </div>
                        <div class="col-md-3">
                        </div>
                         <div class="col-md-3">
                         </div>  
                  </div>
                      <div class="row" style="margin-bottom:5px;">
                  <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblSalesChannel" runat="server"  Height="22px" Width="150px" CssClass="control-label"></asp:Label>
                   </div>
                  <div class="col-md-3">
                            <asp:UpdatePanel ID="upddlSales" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSalesChannel" runat="server"  TabIndex="2" AutoPostBack="True"  CssClass="form-control"
                                        OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                    </div>
                  <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblChnnlClass" runat="server" Height="22px" Width="150px" CssClass="control-label"></asp:Label>
                     </div>
                  <div class="col-md-3">
                            <asp:UpdatePanel ID="upddlChnlCls" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChnnlClass" runat="server"  TabIndex="3" CssClass="form-control"  OnSelectedIndexChanged="ddlChnnlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </div>
                </div>
                   <div class="row">
                  
                   </div>
                    </div>
     
              <div class="col-md-12" style="text-align:center">
                            <input id="flgHidden" type="hidden" />                          
                                    <asp:LinkButton ID="btnSearch" OnClientClick="Enable()" runat="server"  CssClass="btn btn-success" style='margin-top:10px;'
                                OnClick="btnSearch_Click"  >
                                  <span class="glyphicon glyphicon-search BtnGlyphicon" style="color:White"> </span> SEARCH
               
                                </asp:LinkButton> 
                                    &nbsp;&nbsp;

                                     <asp:LinkButton ID="btnClear" runat="server"   CssClass="btn btn-clear"  
                              CausesValidation="false" OnClick="btnClear_Click" TabIndex="5" OnClientClick="return validate();" >
                                  <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color:#f04e5e"> </span> CLEAR
               
                                </asp:LinkButton> 
                  </div>
               </div>
          <table align="center" width="75%" > 
               <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" Width="659px"></asp:Label>
                </td>
            </tr>
                    
                </table>
                <br />
                
                        <div class="card PanelInsideTab" id="divcmpsrchhdrcollapse" runat="server" style ="margin-left: 0% !important;margin-right: 0% !important;">
                            <div id="Div2" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divkpisrch','btndivkpisrch');return false;">
                                <div class="row" id="trDetails" runat="server" style="margin-bottom: 12px;">
                                    <div class="col-sm-10" style="text-align: left">
                                        <div class="col-sm-6">
                                        <asp:Label ID="lblAgtTypSearchRes" runat="server"  CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>

                                        </div>
                                        <div class="col-sm-6">
                                                  <img id="Loading_gif" style="display:none;  margin-top:5px;margin-right:100px" runat="server" 
                                                    src="../Recruit/assets/img/animated_gif_loader.gif"/>
                                        </div>
                                   
                                        </div>
                                    <div class="col-sm-2">
                                        <span id="btndivkpisrch" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divkpisrch"  class="card"  runat="server"  >
                               
                                    <div id="Div1" runat="server" style="overflow: auto">
                                                <asp:GridView AllowSorting="True" ID="dgDetails" runat="server" CssClass="footable"
                                                    AutoGenerateColumns="False" PageSize="50" AllowPaging="true" CellPadding="1"
                                                    OnRowDeleting="dgDetails_RowDeleting" OnRowDataBound="dgDetails_RowDataBound"
                                                    OnSorting="dgDetails_Sorting" >
                                                    <FooterStyle CssClass="GridViewFooter" />
                                                    <RowStyle CssClass="GridViewRowNew" />
                                                    <HeaderStyle CssClass="gridview" />
                                                    <PagerStyle CssClass="disablepage" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                                    <%--<AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                                                    <Columns>
                                                        <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType" />
                                                        <asp:BoundField DataField="ChannelDesc" HeaderText="Hierarchy Name" SortExpression="ChannelDesc">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ChnlDesc" HeaderText="Sub Class" SortExpression="ChnlDesc">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UnitRank" HeaderText="Unit Rank" SortExpression="UnitRank" />
                                                        <asp:BoundField DataField="MemLevel" HeaderText="Member Level" SortExpression="MemLevel" />
                                                        <asp:BoundField DataField="MemTypeDesc01" HeaderText="Member Type Description" SortExpression="MemTypeDesc01">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:BoundField>
                                                         

                                        
                                                        <%--Added by raj for icon--%>
                                                      <%--      <asp:BoundField DataField="" HeaderText="Add Member Type"  >
                                                            <ItemStyle HorizontalAlign="center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:BoundField>--%>
                                                       
                                               <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--<asp:HyperLink ID="lnkView" Text="View"  OnClientClick="funPopUp();" NavigateUrl="javascript:;" runat="server"   OnClientClick="funPopUp();return false;" />--%>  
                                                            <asp:LinkButton ID="lnkAddMemType" runat="server"  OnClientClick="funPopUp(this.id);return false;"  
                                                                data-toggle="tooltip" data-placement="left" title="Add new member type below" Text="">
                                                              <asp:Image ID="imgMember" runat="server"  ImageUrl="../../../assets/img/Add_member_type.png" style="border-width: 0px;" />
                                                         </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                         <%--Added by raj for icon--%>

                                                        <asp:TemplateField >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmemtyp" runat="server" Text='<%#Bind("MemType")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad2" Font-Bold="False" ></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbizsrc" runat="server" Text='<%#Bind("BizSrc")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad2" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblchncls" runat="server" Text='<%#Bind("ChnCls")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad2" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField ShowHeader="True"  HeaderText="Delete" Visible="false">
                                                            <ItemTemplate>
                                                                <div style="width: 100%;display:none">
                                                                    <i class="fa fa-trash-o"></i>
                                                                    <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" Text="Delete" Visible="false" />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad2" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                           <%-- </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                        <br />
                                        <center>
                                        <div id="divPage" visible="true" runat="server" style="margin-left: 555px">
                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                        </div>
                                        <br />
                                    </center>
                                    </div>
                                  <br />
                                    
                                   
                                   
                               
                            </div>  
                           
                             
                          
                        </div>
                         
                 <div class="row">
                                <div class="col-md-12" style='margin-left:2%;' align="center">
                                  
                                    <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-primary" CausesValidation="false" style='margin-top:10px;margin-bottom:10px;'
                                        OnClick="btnAddNew_Click" Visible="false" TabIndex="6">
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> ADD NEW
               
                                    </asp:LinkButton>
                                    &nbsp;&nbsp;
                               
                                    <asp:LinkButton ID="btnCopy" runat="server" Visible="false" CssClass="btn btn-sample" CausesValidation="false" style='margin-top:10px;margin-bottom:10px;'
                                        OnClick="btnCopy_Click" TabIndex="7">
                                  <span class="glyphicon glyphicon-duplicate" style="color:White"> </span> COPY HIERARCHY
               
                                    </asp:LinkButton>
                                </div>
                            </div>
                <br />
                
                <div class="panel" id="divCopy" runat="server" style ="margin-left: 2% !important;margin-right: 2% !important;">
                    <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divUnittypecopy','btndivUnittypecopy');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Text="Hirearchy Copy" CssClass="control-label"  Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btndivUnittypecopy" class="glyphicon glyphicon-chevron-down" style="float: right;
                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                   
                            <div id="divUnittypecopy" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblChnl" runat="server" Text="Hierarchy Name" CssClass="control-label" />
                                    </div>
                                    <div class="col-md-3">
                                    <%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>--%>
                                                <asp:DropDownList ID="ddlChnl" TabIndex="8" runat="server" CssClass="form-control" AutoPostBack="true"
                                                    onselectedindexchanged="ddlChnl_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                           <%-- </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblRank" runat="server" CssClass="control-label" Height="22px" Text="Sub Class"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSubclass" TabIndex="9" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlChnl" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center">                                    
                                        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" CausesValidation="false" style='margin-top:10px;'
                                            OnClick="btnUpdate_Click" TabIndex="10">
                                  <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Update
               
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                              </div>
                       
                  


          
   <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" >
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl_popup" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-verify" data-dismiss="modal" style='margin-top:-6px;border-radius: 15px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
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
                </table>
                <table>
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lbl" runat="server"></asp:Label><br />
                            </center>
                            <br />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>


<%--            <asp:Label runat="server" ID="Label7" Style="display: none" />


    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupview" BehaviorID="ModalPopupviewBID"
        DropShadow="false" TargetControlID="Label7" PopupControlID="pnlview" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>--%>

        <!-- Modal Popup -->
<div id="MyPopup" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    &times;</button>
                <h4 class="modal-title">
                </h4>
            </div>
            <div class="modal-body">
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>
</div>
<!-- Modal Popup -->

    <asp:HiddenField ID="hdngvbizsrc" runat="server" />
        <asp:HiddenField ID="hdngvchncls" runat="server" />
        <asp:HiddenField ID="hdngvmemtype" runat="server" />
     
   <%-- </center>--%>
    <%--Added by Pranjali on 28-05-2013 for modal popup end--%>
</asp:Content>
