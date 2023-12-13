<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="ModuleGroup.aspx.cs" Inherits="Application_Admin_ModuleGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />

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

       		        function ShowReqDtl1(divName, btnName) {
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
                ////ShowError(err.description);
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
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #F04E5E!important;
            color: White;
            white-space: nowrap
        }
    </style>


       <center>
            <div id="divfinhdrcollapse" runat="server" style="width: 95%;" class="panel-body">
           <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
    
        <asp:View ID="v0" runat="server">

         <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg');return false;">
                <div class="row" style="padding-top: 30px;">
                    <div class="col-sm-10" style="text-align: left">
                     
                        <asp:Label ID="lblTitle"   runat="server" Style="font-size:19px;" />
                    </div>
                    <div class="col-sm-2">
                         <asp:Label ID="lblModVer" Visible="false"   runat="server" Style="font-size:19px;" />
                        <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>

           <div id="divfinhdr" runat="server" style="width: 100%;padding-top: 85px;">  <%-- class="panel-body"--%>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand"
             AllowSorting="True" OnPreRender ="GridView1_PreRender" OnRowDataBound="GridView1_RowDataBound"
            AutoGenerateColumns="False" DataKeyNames="UserGroupCode" AllowPaging="True" 
            CellPadding="1"   GridLines="Vertical" HorizontalAlign="Center" Width="500px" CssClass="footable">
             <RowStyle CssClass="GridViewRowNEW"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
            <Columns>
            <asp:TemplateField HeaderText="User Group Code" SortExpression ="UserGroupCode">
                <EditItemTemplate>
                    <asp:Label ID="lblUserGroupCode" runat="server"  Text='<%# Eval("UserGroupCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="UserGroupCode" runat="server" Text='<%# Bind("UserGroupCode") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Group Name" SortExpression="UserGroupName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserGroupName") %>' CssClass="T1" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVCarrierCode2" runat="server" ControlToValidate="TextBox1"
                         display="dynamic" ErrorMessage="" Font-Size="8pt" CssClass="msgerror" ValidationGroup="group2"></asp:RequiredFieldValidator >
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" 
                        Display="Dynamic" ErrorMessage="Alphanumeric only!" SetFocusOnError="true" ValidationExpression="\w*\d*" Font-Size="8pt" CssClass="msgerror" ValidationGroup="group2"></asp:RegularExpressionValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="UserGroupName" runat="server" Text='<%# Bind("UserGroupName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"  />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Access For" SortExpression="AccessFor">
                    <ItemTemplate>
                        <asp:Label ID="AccessForDesc" runat="server" Text='<%# Eval("AccessForDesc") %>'></asp:Label>
                        <asp:Label ID="AccessFor" runat="server" Text='<%# Bind("AccessFor") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="T1" DataSourceID="SqlDataSource2"
                            DataTextField="ParamDesc01" DataValueField="ParamValue" SelectedValue='<%# Bind("AccessFor", "{0}") %>'>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" Visible="False">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False" Visible="False">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Edit"  CssClass="T1">[Edit]</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton5" runat="server"  CommandName="Delete" ToolTip="Delete" CssClass="T1">[Delete]</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Template" ToolTip="Module Sanctioning"  CssClass="T1">[Module Sanctioning]</asp:LinkButton> 
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Update"  CssClass="T1" ValidationGroup="group2">[Update]</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Cancel" CssClass="T1">[Cancel]</asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>
            </Columns>
            <%-- <HeaderStyle CssClass="titlebar"/>--%>
            <AlternatingRowStyle CssClass="sublinkeven" />
            <RowStyle CssClass="sublinkodd" />
            <PagerStyle CssClass="pagelink" />
             
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecord" runat="server" Text="No Record Found"></asp:Label>
            </EmptyDataTemplate> 
            </asp:GridView>
            <br />
             </div>

           <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnNewUser" runat="server" CssClass="btn btn-sample" OnClick="btnNewUser_Click">
                          <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> ADD 
                        </asp:LinkButton>
                        </div>
               </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDirectConnectionString %>"
            SelectCommand="prc_Adm_GetUserGroupList"
            UpdateCommand="UPDATE iUsrGrpSu SET UserGroupName=@UserGroupName,AccessFor=@AccessFor WHERE (UserGroupCode = @UserGroupCode) " 
            DeleteCommand="DELETE FROM iUsrGrpSu WHERE UserGroupCode = @UserGroupCode"
            OnDeleting="OnRecordDeleting" SelectCommandType="StoredProcedure" >
        <UpdateParameters>
           <asp:ControlParameter ControlID="GridView1" Name="UserGroupName" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="GridView1" Name="UserGroupCode" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="GridView1" Name="AccessFor" PropertyName="SelectedValue" Type="String"/>
        </UpdateParameters>
        <DeleteParameters>
            <asp:ControlParameter ControlID="GridView1" Name="UserGroupCode" PropertyName="SelectedValue" />
        </DeleteParameters>
    </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDataConnectionString %>"
            SelectCommand="Select ParamValue,ParamDesc01 from isyslookupparam WHERE lookupcode ='GrpAcsFor' order by SortOrder&#13;&#10;">
        </asp:SqlDataSource>

             
            <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Auto" Width="493px" HorizontalAlign="Left" BackColor="#f2f5ff"  Visible="false" 
             BorderColor="black" BorderStyle="solid" BorderWidth="1px"  style="z-index: 2; left: 371pt; position: absolute; top: 125pt; text-align:center;" >   <%-- --%>
                <strong><span style="font-family: Tahoma">
                 <asp:Label ID="lblSelectedModule" runat="server" Text="Module Access Matrix for User Group"></asp:Label></span></strong>
          <%-- <strong><span id="title" class="title" runat="server">&nbsp;Module Access Matrix for User Group "Internal"</span>
        </strong> --%>
        <%-- <div class="col-sm-6" style="height: 320px;" valign="top">--%>
                         <asp:Panel ID="Panel2" Height="300px" runat="server"  ScrollBars="Auto">  
       <asp:TreeView ID="TrVModule" runat="server" Height="388px" ShowCheckBoxes="All" ShowLines="True"
            Width="468px" CssClass="T1" Style="text-align: left">
            <LeafNodeStyle CssClass="T1" />
           <ParentNodeStyle CssClass="T1" />
          <RootNodeStyle CssClass="T1" />
           <NodeStyle CssClass="T1" />
       </asp:TreeView>

       </asp:Panel> 
                         <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" OnClick="btnUpdate_Click">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Update
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnClose" runat="server" CssClass="btn btn-sample" OnClick="btnClose_Click">
                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                        </asp:LinkButton>
                    </div>
                </div>

       <asp:CheckBox Visible="false" ID="CheckBox1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="Small" Text="Apply to all existing user" Width="345px" />
       <asp:Label ID="lblUGID" runat="server" Visible="False" />
       <asp:Label ID="lblUGName" runat="server" Visible="False"/>
       <asp:Label ID="lblUGCC" runat="server" Visible="False"/>
       <asp:Label ID="lblAccessFor" runat="server" Visible="False"/>
       <script type="text/javascript">
           function OnTreeClick(evt) {
               var src = window.event != window.undefined ? window.event.srcElement : evt.target;
               var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
               if (isChkBoxClick) {
                   var parentTable = GetParentByTagName("table", src);
                   var nxtSibling = parentTable.nextSibling;

                   //check if nxt sibling is not null & is an element node
                   if (nxtSibling && nxtSibling.nodeType == 1) {
                       if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                       {
                           //check or uncheck children at all levels
                           CheckUncheckChildren(parentTable.nextSibling, src.checked, src);
                       }
                   }
                   //check or uncheck parents at all levels
                   CheckUncheckParents(src, src.checked);
               }
           }

           function CheckUncheckChildren(childContainer, check, chkBox) {
               var childChkBoxes = childContainer.getElementsByTagName("input");
               //var childChkBoxCount = childChkBoxes.length;
               //var parentDiv = GetParentByTagName("div", chkBox);
               //var checkBoxCount = parentDiv.childNodes.length;
               var checkBoxCount = childChkBoxes.length;
               for (var i = 0; i < checkBoxCount; i++) {
                   childChkBoxes[i].checked = check;
               }
           }

           function CheckUncheckParents(srcChild, check) {
               var parentDiv = GetParentByTagName("div", srcChild);
               var parentNodeTable = parentDiv.previousSibling;
               if (parentNodeTable) {
                   var checkUncheckSwitch;
                   if (check) //checkbox checked
                   {
                       var isAllSiblingsChecked = AreAllSiblingsChecked1(srcChild);
                       if (isAllSiblingsChecked)
                           checkUncheckSwitch = true;
                       else
                           checkUncheckSwitch = true; //return; //do not need to check parent if any(one or more) child not checked
                   }
                   else //checkbox unchecked
                   {
                       var isAllSiblingsChecked1 = AreAllSiblingsChecked1(srcChild);
                       if (isAllSiblingsChecked1)
                           checkUncheckSwitch = true;
                       else
                           checkUncheckSwitch = false;
                   }

                   var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                   if (inpElemsInParentTable.length > 0) {
                       var parentNodeChkBox = inpElemsInParentTable[0];
                       parentNodeChkBox.checked = checkUncheckSwitch;
                       //do the same recursively
                       CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                   }
               }
           }

           function AreAllSiblingsChecked(chkBox) {
               var parentDiv = GetParentByTagName("div", chkBox);
               var childCount = parentDiv.childNodes.length;
               for (var i = 0; i < childCount; i++) {
                   if (parentDiv.childNodes[i].nodeType == 1) {
                       //check if the child node is an element node
                       if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                           var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                           //if any of sibling nodes are not checked, return false
                           if (!prevChkBox.checked) {
                               return false;
                           }
                       }
                   }
               }
               return true;
           }

           function AreAllSiblingsChecked1(chkBox) {
               var parentDiv = GetParentByTagName("div", chkBox);
               var childCount = parentDiv.childNodes.length;
               var blnDirty = false;
               for (var i = 0; i < childCount; i++) {
                   if (parentDiv.childNodes[i].nodeType == 1) {
                       //check if the child node is an element node
                       if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                           var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                           //if any of sibling nodes are not checked, return false
                           if (prevChkBox.checked) {
                               blnDirty = true;
                           }
                       }
                   }
               }

               if (blnDirty)
                   return true;
               else
                   return false;
           }

           //utility function to get the container of an element by tagname
           function GetParentByTagName(parentTagName, childElementObj) {
               var parent = childElementObj.parentNode;
               while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                   parent = parent.parentNode;
               }
               return parent;
           }

       
       
       </script>

         </asp:Panel>
   
        
    </asp:View>
                                 
        <asp:View ID="v2" runat="server">
        <%--<div style="text-align:center;">--%>

                  <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                     
                        <asp:Label ID="lblTitle2"   runat="server" Style="font-size:19px;" />
                    </div>
                    <div class="col-sm-2">
                         <asp:Label ID="lblModVer2" Visible="false"   runat="server" Style="font-size:19px;" />
                        <span id="myImg1"  class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>  <%-- class="glyphicon glyphicon-menu-hamburger"--%>
                    </div>
                </div>
            </div>
                 <div>
            <asp:DetailsView ID="DetailsView1" runat="server" DataKeyNames="UserGroupCode"
                DataSourceID="SqlDataSource1" DefaultMode="Insert"  OnPreRender ="DetailsView1_PreRender" 
                AutoGenerateRows="False" Width="100%" OnItemCommand="DetailsView1_ItemCommand" CssClass="footable" >
            <FieldHeaderStyle Width="20%" HorizontalAlign="Left"  CssClass="H1"/> 
            <InsertRowStyle HorizontalAlign="Left" />
                <Fields>
                    <asp:TemplateField HeaderText="User Group Code &lt;font color='red'&gt; * &lt;/font&gt;">
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtNewGrpCode" runat="server" Text='<%# Bind("UserGroupCode") %>' CssClass="form-control" MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVUserGroupCode" runat="server" ControlToValidate="txtNewGrpCode"
                                display="dynamic" ErrorMessage="Required Field!" Font-Size="8pt" CssClass="msgerror" ValidationGroup="Grp1"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewGrpCode" 
                                Display="Dynamic" ErrorMessage="Alphanumeric only!" SetFocusOnError="true" ValidationExpression="\w*\d*" Font-Size="8pt" CssClass="msgerror" ValidationGroup="Grp1"></asp:RegularExpressionValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserGroupCode") %>' CssClass="T1"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="subtitle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Group Name &lt;font color='red'&gt; * &lt;/font&gt;">
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtNewGrpNm" runat="server" Text='<%# Bind("UserGroupName") %>' CssClass="form-control" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVUserGroupName" runat="server" ControlToValidate="txtNewGrpNm"
                                display="dynamic" ErrorMessage="Required Field!" Font-Size="8pt" CssClass="msgerror" ValidationGroup="Grp1"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNewGrpNm" 
                                Display="Dynamic" ErrorMessage="Alphanumeric only!" SetFocusOnError="true" ValidationExpression="\w*\d*" Font-Size="8pt" CssClass="msgerror" ValidationGroup="Grp1"></asp:RegularExpressionValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("UserGroupName") %>' CssClass="T1"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="subtitle" />
                    </asp:TemplateField>    
                    <asp:TemplateField HeaderText="Access For &lt;font color='red'&gt; * &lt;/font&gt;">
                        <InsertItemTemplate>
                            <asp:DropDownList ID="ddlAccessFor" runat="server"   DataSourceID="SqlDataSource2" CssClass="form-control"
                            DataTextField="ParamDesc01" DataValueField="ParamValue" SelectedValue='<%# Bind("AccessFor", "{0}") %>'>
                            </asp:DropDownList>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" CssClass="T1" Text='<%# Bind("AccessFor") %>'></asp:Label>
                        </ItemTemplate>
                         <HeaderStyle CssClass="subtitle" />
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>

    </div>
            <br />
                
              <div class="row" style="margin-top: 41px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnInsert" runat="server" CssClass="btn btn-sample" OnClick="btnInsert_Click" ValidationGroup="Grp1">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Insert
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnClose2" runat="server" CssClass="btn btn-sample" OnClick="btnClose2_Click">
                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Close
                        </asp:LinkButton>
                    </div>
                </div>
        </asp:View>
       </asp:MultiView>
         </div>
       <div id="PnlBlocker" style="display:none;z-index: 1; filter: alpha(opacity=40); left: -18px; width: 102%;
        position: absolute; top: 0px; height: 65%; background-color: #cccccc; moz-opacity: .40;
        opacity: .40" runat="server">
        <table id="Table1" runat="server" style="height: 900px;">
            <tr>
                <td style="width: 90%; height: 496px">
                </td>
            </tr>
        </table>
    </div>
       </center>
</asp:Content>

