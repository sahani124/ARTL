<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MSTACTVALSU.aspx.cs" Inherits="Application_Isys_Saim_Customisation_MSTACTVALSU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />--%>


    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />

    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="..//../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <style type="text/css">
        .location {
            text-align: right;
        }

        .CenterAlign
        {text-align:center !important;}
         .LeftAlign
        {text-align:left !important;}
         .RightAlign
        {text-align:right !important;}
        
    </style>
    <script type="text/javascript">
        function ShowReqDtl1(divName, btnName) {

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

        function CloseDiv(divId) {

            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + divId) != null) {
                document.getElementById(strContent + divId).style.display = 'none';
            }
        }

    

        function populateGridCalender(obj) {
            $(obj).datepicker({
                dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                    }
                }
            });
        }


        function fnCallPOP(KPICode, ACT_TYP, BSD_ON_TBL_TYP) {
            debugger;
            $find("mdlPopBIDHybrid").show();
            var Mode = "B";
            var strContent = "ctl00_ContentPlaceHolder1_";

            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = ("POP_MST_ACT_VAL_SU.aspx?&KPICode=" + KPICode + "&ACT_TYP=" + ACT_TYP +
           "&BSD_ON_TBL_TYP=" + BSD_ON_TBL_TYP + "&mdlpopup=mdlPopBIDHybrid"); 
            return false;
        }
    </script>



    <div id="divsrchdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%" class="panel">
        <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmpSrch','SrchImg');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <%--                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                    <asp:Label ID="Label2" Text="Search Val Factor" Font-Size="19px" runat="server" />
                </div>
                <div class="col-sm-2">
                    <span id="SrchImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 24/4/2018--%>
                </div>
            </div>
        </div>

        <div id="divcmpSrch" runat="server" style="width: 96%;" class="panel-body">
            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblSrVal" Text="Val Code" runat="server" CssClass="control-label" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextSrVal" runat="server" CssClass="form-control" TabIndex="1"
                                MaxLength="8" placeholder="Val Code" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblSrValDesc" Text="Val Description" runat="server" CssClass="control-label" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextSrValDesc" runat="server" CssClass="form-control" TabIndex="1" placeholder="Val Description" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
            <div id="tblSrch" runat="server" class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">
                    <asp:UpdatePanel ID="updsearch" runat="server">
                        <ContentTemplate>
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClick="btnSearch_Click" ClientIDMode="Static">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                    </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </div>
            </div>

        </div>

    </div>

    <div id="div1" runat="server" style="margin-left: 2.7%; margin-right: 2.7%; margin-top: 0.5%" class="panel">


        <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','myImg1');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label1" Text="Val Factor Results" Font-Size="19px" runat="server" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>

          <div id="div3" runat="server" style="width: 98%; overflow-x:scroll" >
            <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grvaddedresult" runat="server" AutoGenerateColumns="false" OnRowEditing= "grvaddedresult_RowEditing"
                          OnSorting="grvaddedresult_Sorting" OnRowCancelingEdit="grvaddedresult_RowCancelingEdit" OnRowDeleting="grvaddedresult_RowDeleting" OnRowUpdating="grvaddedresult_RowUpdating"
                        Style="margin-right: 1%; margin-top: 0.3%; margin-bottom: 0.3%; margin-left: 1%"  CssClass="footable"
                        CellPadding="4" AllowSorting="True"  ShowFooter="false"
                        AllowPaging="True" PageSize="5" ForeColor="#333333" GridLines="None">
                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                        <PagerStyle CssClass="disablepage" />
                        <HeaderStyle CssClass="gridview th" />
                        <EmptyDataTemplate>
                                                <asp:Label ID="lblactvler" Text="No records found" ForeColor="Red" CssClass="control-label" runat="server" />
                                            </EmptyDataTemplate>
                        <Columns>
                            
                             <asp:TemplateField HeaderText="Mapped Code" SortExpression="MAP_CODE" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"  CssClass="CenterAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMappedCd" runat="server" Text='<%# Bind("MAP_CODE")%>' />
                                     <asp:Label ID="LBLSEQNO" runat="server" Text='<%# Bind("SEQ_NO")%>' Visible="false" />
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtMappedCd" Enabled="false" CssClass="form-control" Text='<%# Bind("MAP_CODE")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>--%>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Val Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                SortExpression="VAL_CODE">
                                <ItemStyle HorizontalAlign="Center"  CssClass="LeftAlign" />
                                <ItemTemplate >
                                  <%--  <asp:LinkButton ID="lblValCode" runat="server" Text='<%# Bind("VAL_CODE")%>'> </asp:LinkButton>--%>
                                    <asp:Label ID="lblValCode" runat="server" Text='<%# Bind("VAL_CODE")%>' CssClass="location" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtValCode" Text='<%# Bind("VAL_CODE")%>' CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                           

                            <asp:TemplateField HeaderText="Val  Description" SortExpression="VAL_DESC" ItemStyle-HorizontalAlign="left" > 
                               
                                <ItemStyle HorizontalAlign="Right"  CssClass="LeftAlign" />
                                <HeaderStyle CssClass="location" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVAL_DESC" runat="server" Text='<%# Bind("VAL_DESC")%>' CssClass="location" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtVAL_DESC" CssClass="form-control" Text='<%# Bind("VAL_DESC")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Factor Flag" SortExpression="IS_FX_RG_FLAG" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Center" CssClass="LeftAlign"  />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIS_FX_RG_FLAG" runat="server" Text='<%# Bind("IS_FX_RG_FLAG_DESC")%>' />
                                        
                                    
                                </ItemTemplate>
                                <EditItemTemplate>
                                     <asp:UpdatePanel ID="updfr" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlIS_FX_RG_FLAG" Width="100px" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIS_FX_RG_FLAG_SelectedIndexChanged"  >
                                    </asp:DropDownList>
                            </ContentTemplate>
                                         </asp:UpdatePanel>
                                     <asp:HiddenField ID="hdnIS_FX_RG_FLAG" runat="server" Value='<%# Bind("IS_FX_RG_FLAG")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status" SortExpression="STATUS" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Center"   CssClass="LeftAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSTATUS" runat="server" Text='<%# Bind("STATUS_DESC")%>' />
                               

                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:UpdatePanel ID="updsts" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlSTATUS" Width="100px" CssClass="form-control" ClientIDMode="inherit" runat="server" >
                                        <%--OnSelectedIndexChanged="ddlSTATUS_selectedIndexChanged" --%>
                                    </asp:DropDownList>
                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                         <asp:HiddenField ID="hdnSTATUS" runat="server" Value='<%# Bind("STATUS")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Base / Source Table Name" SortExpression="BASE_DATA_TBL_NAME_DESC" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Center"  CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBaseTableName" runat="server" Text='<%# Bind("BASE_DATA_TBL_NAME_DESC")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:UpdatePanel ID="updbs" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlBaseTableName" Width="200px" CssClass="form-control" runat="server"  OnSelectedIndexChanged="ddlBaseTableName_SelectedIndexChanged" AutoPostBack="true"> <%--OnSelectedIndexChanged="ddlBaseTableName_SelectedIndexChanged"--%>
                                       </asp:DropDownList>
                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                      <asp:HiddenField ID="hdnddlBaseTableName" runat="server" Value='<%# Bind("BASE_DATA_TBL_NAME")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderText="Base / Source Table Column" SortExpression="BASE_DATA_TBL_COL_NAME" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Center"   CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBASE_TBL_COL_NAME" runat="server" Text='<%# Bind("BASE_DATA_TBL_COL_NAME")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:UpdatePanel ID="updbscol" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlBASE_TBL_COL_NAME" Width="100px" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:DropDownList>
                            </ContentTemplate>
                            </asp:UpdatePanel>    
                            <asp:HiddenField ID="hdnBASE_DATA_TBL_COL_NAME" runat="server" Value='<%# Bind("BASE_DATA_TBL_COL_NAME")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Master Table Name" SortExpression="MASTER_NAME" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Center"   CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblmstrnm" runat="server" Text='<%# Bind("MASTER_NAME")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                  <asp:UpdatePanel ID="updms" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlMaster_TBL_NAME" Width="100px" CssClass="form-control"  runat="server" OnSelectedIndexChanged="ddlMaster_TBL_NAME_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          </ContentTemplate>
                             </asp:UpdatePanel>  
                            <asp:HiddenField ID="hdnMaster_TBL_NAME" runat="server" Value='<%# Bind("MASTER_NAME")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>

                          
                            <asp:TemplateField HeaderText="Master Column Code" SortExpression="MASTER_COL_NAME" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Center"   CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblmstrcolnm" runat="server" Text='<%# Bind("MASTER_COL_NAME")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:UpdatePanel ID="updmscol" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlMaster_TBL_COL_NAME" Width="100px" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:DropDownList>
                           </ContentTemplate>
                                  </asp:UpdatePanel>    
                            <asp:HiddenField ID="hdnMasterDATA_TBL_COL_NAME" runat="server" Value='<%# Bind("MASTER_COL_NAME")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Master Column Description" SortExpression="MASTER_COL_DESC" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Center"   CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblmstrcolnmdesc" runat="server" Text='<%# Bind("MASTER_COL_DESC")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:UpdatePanel ID="updmscolde" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlMaster_Col_Desc" Width="100px" CssClass="form-control" ClientIDMode="Static" runat="server" OnSelectedIndexChanged="ddlMaster_Col_Desc_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                                 </asp:UpdatePanel>    
                            <asp:HiddenField ID="hdnMaster_Col_Desc" runat="server" Value='<%# Bind("MASTER_COL_DESC")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <%-- --%>
                             <asp:TemplateField HeaderText="LookupCode" SortExpression="LookupCode" ItemStyle-HorizontalAlign="left">
                                <ItemStyle HorizontalAlign="Left"   CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lbllookup" runat="server" Text='<%# Bind("LookupCode")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:UpdatePanel ID="updlook" runat="server">
                        <ContentTemplate>
                                    <asp:DropDownList ID="ddllookup" Width="100px" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:DropDownList>
                            </ContentTemplate>
                                 </asp:UpdatePanel>    
                            <asp:HiddenField ID="hdn_lookup" runat="server" Value='<%# Bind("LookupCode")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Effective Date" SortExpression="EFF_DTIM" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"   CssClass="CenterAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEffDate" runat="server" Text='<%# Bind("EFF_DTIM")%>' />
                                </ItemTemplate>
                               <EditItemTemplate>
                                    <asp:TextBox ID="DateTimeValue"  CssClass="form-control" Text='<%# Bind("EFF_DTIM")%>' runat="server" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cease Date" SortExpression="CSE_DTIM" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"   CssClass="CenterAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblceasedt" runat="server" Text='<%# Bind("CSE_DTIM")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtceasedt" onmousedown="populateGridCalender(this)" onmouseover="populateGridCalender(this)" CssClass="form-control" Text='<%# Bind("CSE_DTIM")%>' runat="server" ClientIDMode="Static"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>


<%--                           
                            <asp:TemplateField HeaderText="Execution Order" SortExpression="EXCTN_ORDR" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblexecorder" runat="server" Text='<%# Bind("EXCTN_ORDR")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlEcecuteEdit" CssClass="form-control" ClientIDMode="Static" Width="100px" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Action">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" ShowEditButton="true"   CommandName="Edit" runat="server" /> |
                                 
                                     <asp:LinkButton ID="lnkDelAct" runat="server" ShowEditButton="true" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                            CommandName="Delete"        ></asp:LinkButton>

                                </ItemTemplate>

                               <EditItemTemplate>
                                 
                                       <asp:LinkButton ID="btnUpdate" Text="Update" ShowEditButton="true" CommandName="Update" runat="server" /> | <%--OnClick="btnUpdate_Click" --%>
                                    <asp:LinkButton ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" ShowEditButton="true" CommandName="Cancel" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
              <br />
               
             <center> 
                
            <asp:UpdatePanel ID="upvlbtn" runat="server">
                 <ContentTemplate>
                   <asp:LinkButton ID="btnadd" runat="server"  CssClass="btn btn-sample" TabIndex="17" OnClick="btnadd_Click">
                                            <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color:White"></span> Add
                    </asp:LinkButton> 
                     <%--</ContentTemplate>
                </asp:UpdatePanel>
                    <asp:UpdatePanel ID="updcngnrt" runat="server">
                 <ContentTemplate>--%>
                 <asp:LinkButton ID="lnkbtngnrt" runat="server"  CssClass="btn btn-sample" TabIndex="17" OnClick="lnkbtngnrt_Click">
                                             <span class="glyphicon glyphicon-edit" style="color:white;"></span> Generate
                    </asp:LinkButton> 
                      <asp:LinkButton ID="btncncl" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClientClick="JavaScript:window.history.back(1); return false;">
                                     <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color: White;"></span> Cancel
                                   </asp:LinkButton>
                 </ContentTemplate>
            </asp:UpdatePanel>
                 <br /> 
            <div class="pagination" style="padding: 10px;">
                      
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <%--background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />--%>
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true"  Text="1"/>
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                    <%--float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />--%>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                
                        </div>
              
 </center>

        </div>




    </div>

     <asp:Button ID="BtnToolTip" runat="server" Text="BtnToolTip" Style="display: none" OnClick="BtnToolTip_Click"/>
    <asp:Button ID="BtnToolTip2" runat="server" Text="BtnToolTip" Style="display: none" OnClick="BtnToolTip2_Click"/>

<asp:Panel runat="server" Height="430px" Width="1090px" ID="Panel1" display="none" Style="text-align: center; top: 59px !important; padding: 5px; left: -2px !important; margin-left: -8px;" CssClass="panel panel-success">
        <iframe runat="server" id="Iframe1" scrolling="yes" width="100%" frameborder="0" display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpnl10" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDHybrid"
        DropShadow="false" TargetControlID="lblpnl10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg" X="-4" Y="0">
    </ajaxToolkit:ModalPopupExtender>

      <asp:HiddenField ID="hdnMapDataType1" runat="server" />
    <asp:HiddenField ID="hdnMapDataType2" runat="server" />
    <asp:HiddenField ID="hdnCol1DT" runat="server" />
    <asp:HiddenField ID="hdnCol2DT" runat="server" />

</asp:Content>


<%--protected void grvMapping_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                string lblChannel = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblChannel")).Text;
                string lblsubChannel = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblsubChannel")).Text;
                string lblUnitType = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblUnitType")).Text;
                string lblUnitCode = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblUnitCode")).Text;

                int index = e.NewEditIndex;
                //DataBindGridView();  // this is a method which assigns the DataSource and calls GridView1.DataBind()
                //DropDownList DdlCountry = GridView1.Rows[index].FindControl("DdlCountry") as DropDownList;

                grvMapping.EditIndex = index;
                BindUserMapping();

                DropDownList ddlchn = grvMapping.Rows[index].FindControl("GridDdlchn") as DropDownList;
                DropDownList ddlsubchn = grvMapping.Rows[index].FindControl("GridDdlsubchn") as DropDownList;
                DropDownList ddlunittyp = grvMapping.Rows[index].FindControl("GridDdlunittyp") as DropDownList;
                DropDownList ddlUnitCode = grvMapping.Rows[index].FindControl("GridDdlUnitCode") as DropDownList;

                htParam.Clear();
                dsResult.Clear();
                dsResult = objDal.GetDataSet("Prc_GetChannelType", htParam, "demoConn");
                FillDropdowns(dsResult, ddlchn, true, "Select (Channel)");
                ddlchn.Items.FindByText(lblChannel).Selected = true;


                Hashtable htparam1 = new Hashtable();
                DataSet dsDDL1 = new DataSet();
                htparam1.Add("@channelType", ddlchn.SelectedValue);
                dsDDL1 = objDal.GetDataSet("Prc_GetSubChannelType", htparam1, "demoConn");
                if (dsDDL1.Tables.Count != 0)
                {
                    bindDropdown(ddlsubchn, dsDDL1);
                }
                else
                {
                    ddlsubchn.Items.Clear();
                    ddlunittyp.Items.Clear();                  
                    ddlUnitCode.Items.Clear();
                  
                }
                //ddlsubchn.SelectedValue = lblsubChannel;
                ddlsubchn.Items.FindByText(lblsubChannel).Selected = true;

                Hashtable htparam3 = new Hashtable();
                DataSet dsDDL3 = new DataSet();
                htparam3.Add("@channelType", ddlchn.SelectedValue);
                htparam3.Add("@ddlsubchn", ddlsubchn.SelectedValue);
                dsDDL3 = objDal.GetDataSet("Prc_GetUnitType", htparam3, "demoConn");
                if (dsDDL3.Tables.Count != 0)
                {
                    bindDropdown(ddlunittyp, dsDDL3);
                }
                else
                {
                    ddlunittyp.Items.Clear();
                }
                //ddlunittyp.SelectedValue = lblUnitType;
                ddlunittyp.Items.FindByText(lblUnitType).Selected = true;

                
                Hashtable htparam5 = new Hashtable();
                DataSet dsDDL5 = new DataSet();
                htparam5.Add("@chnl", ddlchn.SelectedValue);
                htparam5.Add("@unttype", ddlunittyp.SelectedValue);
                dsDDL5 = objDal.GetDataSet("Prc_GetUntCodeForLoggedinUser_UserCreation", htparam5, "demoConn");
                if (dsDDL5.Tables.Count != 0)
                {
                    bindDropdown(ddlUnitCode, dsDDL5);
                }
                else
                {
                    ddlUnitCode.Items.Clear();
                  
                }
                //ddlUnitCode.SelectedValue = lblUnitCode;
                ddlUnitCode.Items.FindByText(lblUnitCode).Selected = true;
                ddlsubchn.Items.Insert(0, new ListItem("Select (Sub Channel)", "0"));
                ddlunittyp.Items.Insert(0, new ListItem("Select (Unit Type)", "0"));
                ddlUnitCode.Items.Insert(0, new ListItem("Select (Unit Name)", "0"));
            }

            catch (Exception Ex)
            {
                ErrorLog errObj = new ErrorLog();
            }
        }--%>