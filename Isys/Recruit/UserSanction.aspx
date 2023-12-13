<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="UserSanction.aspx.cs" Inherits="Application_ISys_Recruit_UserSanction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<script type="text/javascript">
    function OnTreeClick(evt) {
        //debugger;
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
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>



<center>
    
    
      
        <asp:UpdatePanel ID="updtbltree" runat="server">
             <ContentTemplate>
      
        <table id="tblHeirarchy" runat="server" cellpadding="3" class="tableborder" cellspacing="1" border="0"  style="width: 80%;"  >

    <tr id="trTree" runat="server"  >
        <td>
            <asp:Panel ID="pnlUpload" runat="server" Height="318px" ScrollBars="Auto" Width="397px" BackColor="#f2f5ff" BorderColor="black" BorderStyle="solid" BorderWidth="1px"
            HorizontalAlign="Center" style="left: 179pt;" Visible="false">
            <strong><span style="font-family: Tahoma" id="title" runat="server">Upload Document</span></strong>
            <table align="center">
                 <tr>
                    <td align="center">
                         <asp:Panel ID="Panel1"  runat="server" ScrollBars="Auto">
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server"> 
                         <ContentTemplate>
                         <%--<atlas:UpdatePanel ID="UpdatePanel2" runat="server"> 
                         <ContentTemplate>--%>
                         <asp:TreeView ID="TrVUser" runat="server" ShowCheckBoxes="All" ShowLines="True"
                                Width="324px"  CssClass="T1" Style="text-align: left">
                            <LeafNodeStyle CssClass="T1" />
                            <ParentNodeStyle CssClass="T1" />
                            <RootNodeStyle CssClass="T1" />
                            <NodeStyle CssClass="T1" />
                            </asp:TreeView>
                            <%--</ContentTemplate>
                          
                            </atlas:UpdatePanel>--%>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </asp:Panel>
                            </td>
                            </tr>
                            
            </table>
            
        </asp:Panel>  
        </td>
        </tr>
        <tr>
        <td>
            <asp:Panel ID="pnlDwnld" runat="server" Height="318px" ScrollBars="Auto" Width="397px" BackColor="#f2f5ff" BorderColor="black" BorderStyle="solid" BorderWidth="1px"
                HorizontalAlign="Center" style="left: 179pt;" Visible="false">
                <strong><span style="font-family: Tahoma" id="Span1" runat="server">Download Document</span></strong>
                <table align="center">
                    <tr>
                        <td align="center">
                            <asp:Panel ID="pnlDwn1" runat="server" ScrollBars="Auto">
                            <asp:UpdatePanel ID="upldDwnld" runat="server">
                                    <ContentTemplate>
                               <%-- <atlas:UpdatePanel ID="upldDwnld" runat="server">
                                    <ContentTemplate>--%>
                                        <asp:TreeView ID="TrDDoc" runat="server" ShowCheckBoxes="All" ShowLines="True"
                                              Width="324px"  CssClass="T1" Style="text-align: left">
                                            <LeafNodeStyle CssClass="T1" />
                                            <ParentNodeStyle CssClass="T1" />
                                            <RootNodeStyle CssClass="T1" />
                                            <NodeStyle CssClass="T1" />
                                        </asp:TreeView>
                                    <%-- </ContentTemplate>
                                </atlas:UpdatePanel>--%>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    
   
        </table>
     
       </ContentTemplate>
       </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
             <ContentTemplate>
       <table id="tblButton" runat="server" >
        <tr>
                            <td align="center" colspan="2">
             <center>
            <asp:CheckBox ID="CheckBox4" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="Small" Text="Apply to all existing user" Width="261px" Visible="false" />
                <br />
            <asp:Button ID="btnUpdate" runat="server" CssClass="standardbutton" Text="Update"
               onclick="btnUpdate_Click"  />&nbsp;                          
            <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="standardbutton" 
                     onclick="btnClose_Click"   />     
            </center>
            </td>
            
            </tr>
       </table>
        </ContentTemplate>
       </asp:UpdatePanel>
        <asp:HiddenField ID="hdnUserId" runat="server" />
         
        
</center>
 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
             <ContentTemplate>
<asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="309px" Height="182px">
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
                        <asp:Label ID="lbl_popup" runat="server"></asp:Label><br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" /></center>
    </asp:Panel>
   
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl_popup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
     </ContentTemplate>
       </asp:UpdatePanel>
</asp:Content>

