<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MstTblDwnDesign.aspx.cs" Inherits="Application_INSC_Recruit_MstTblDwnDesign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        //loading image icon
        function LoadWait(delay) {
            //debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divLoader").style.display = 'block';
            setTimeout("RemoveLoading11()", delay);
        }
        function RemoveLoading11() {
            //debugger;
            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divLoader").style.display = 'none';
        }
        function funMandatory() {

            if (document.getElementById('<%=txtDocDesc.ClientID %>').value == "") {
                alert("Document Description is mandatory.");
                document.getElementById('<%= txtDocDesc.ClientID %>').focus();
                return false;
                var strContent = "ctl00_ContentPlaceHolder1";
                var id = strContent.dgMstDesign.Rows(Me.dgMstDesign.EditItemIndex).FindControl("txtColName").ClientId
            }
            if (document.getElementById('<%=txtShrtDocName.ClientID %>').value == "") {
                alert("Document short code is mandatory.");
                document.getElementById('<%= txtShrtDocName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtColcnt.ClientID %>').value == "") {
                alert("Column count is mandatory.");
                document.getElementById('<%= txtColcnt.ClientID %>').focus();
                return false;
            }
        }
        function ShowReqDtl(divId, btnId) {
            //debugger;
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '-';
            }
        }
        //shreela
        function RestrictSpaceSpecial() {
            //debugger;
            if ((event.keyCode == 32 || event.keyCode == 33 || event.keyCode == 34 || event.keyCode == 35 || event.keyCode == 36 || event.keyCode == 37 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40 || event.keyCode == 41 || event.keyCode == 42 || event.keyCode == 43 || event.keyCode == 44 || event.keyCode == 45 || event.keyCode == 46 || event.keyCode == 47 || event.keyCode == 64)) {
                alert("Special characters restricted");
                event.returnValue = false;

            }
        }
        function Restrict() {
            //debugger;
            if (!(event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) {
                alert("Only numeric values are allowed");
                event.returnValue = false;
            }
        }
        //shreela

        function AlertMsgs(msgs) {
            alert(msgs);
        }

</script>

<asp:ScriptManager ID="SmMstdesign" runat="server">
</asp:ScriptManager>

<center>
  <table id="tblHeader" runat="server" class="tableIsys" style="width: 80%;" > 
       <tr style="height: 20px;">
          <td colspan="4" class="test">
              <asp:Label ID="lblMstDocDesign" runat="server" Font-Bold="True" Width="700px"></asp:Label>
          </td>
       </tr>
       <tr>
          <td class="formcontent" style="width: 20%;">
              <span style="color: red">
              <asp:Label ID="lblDoctype" runat="server" Style="color: black"></asp:Label>*</span>
          </td>
          <td class="formcontent" style="width: 30%;">
              <asp:TextBox ID="txtDoctype" runat="server" CssClass="standardtextbox" MaxLength="8"
                   TabIndex="1"  Width="201px" BackColor="#FFFFB2"></asp:TextBox><%--Enabled="false" BackColor="LightGray" ReadOnly="True"--%>
              <asp:HiddenField ID="hdntxtDoctype" runat="server" />
          </td>
          <td class="formcontent" style="width: 20%;">
              <span style="color: red">
              <asp:Label ID="lblDecDesc" runat="server" Style="color: black"></asp:Label>*</span>
          </td>
          <td class="formcontent" style="width: 30%;">
              <asp:TextBox ID="txtDocDesc" runat="server" width="201px" CssClass="standardtextbox" 
                   TabIndex="2"  BackColor="#FFFFB2" ></asp:TextBox>
          </td>
       </tr>
       <tr>
          <td class="formcontent" style="width: 20%;">
              <span style="color: red">
              <asp:Label ID="lblshrtDocName" runat="server" Style="color: black"></asp:Label>*</span>
          </td>
          <td class="formcontent" style="width: 35%;">
              <asp:UpdatePanel ID="UpdatePanel8" runat="server">
              <ContentTemplate>
              <span style="color: red">
              <asp:TextBox ID="txtShrtDocName" width="201px" runat="server" CssClass="standardtextbox" MaxLength="7"
                   onChange="javascript:this.value=this.value.toUpperCase();"   BackColor="#FFFFB2" TabIndex="3" ></asp:TextBox>
              <asp:Label ID="lblshrt" runat="server" text="(eg.DAAAAAA)" style="color: red"></asp:Label>
              </ContentTemplate>
              </asp:UpdatePanel>
           </td>
           <td class="formcontent" style="width: 20%;">
               <span style="color: red">
               <asp:Label ID="lblColcnt" runat="server" Style="color: black"></asp:Label>*</span>
           </td>
           <td class="formcontent" style="width: 30%;">
               <asp:TextBox ID="txtColcnt" runat="server" width="201px" CssClass="standardtextbox" 
                    TabIndex="4"  BackColor="#FFFFB2" onkeypress="Restrict()"></asp:TextBox>
               <asp:HiddenField ID="hdnColcnt" runat="server" />     
           </td>
       </tr>
      <tr>
                <td class="formcontent" style="width: 20%;">
                    <span style="color: red"><asp:Label ID="lblDwnldfrmt" runat="server" Text="Download Format" Style="color: black"></asp:Label>*</span>
                </td>
                <td class="formcontent">
                     <asp:UpdatePanel ID="upldDwnldFrmt" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlDwnldFrmt" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                    Width="150px" BackColor="#FFFFB2"  TabIndex="5">
                                </asp:DropDownList>&nbsp;&nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
            </tr>
       <tr>
           <td colspan="2" align="right" style="height: 20px;">
          <%-- <div class="btn btn-xs btn-primary"><i class="fa fa-flash"></i>--%>
               <asp:Button ID="btnInsert" runat="server" CssClass="standardbutton" TabIndex="6"
                    Text="Start Design" Width="114px" onclick="btnInsert_Click" OnClientClick="LoadWait(100000)"/><%--</div>--%>
           </td>
           <td  colspan="2" align="left" style="height: 20px;" >
               <div id="divloader" runat="server" style="display:none;">
                     &nbsp;&nbsp; <img id="Img1" alt="" src="../../../app_themes/isys/images/spinner.gif" runat="server" /> Loading...
               </div>
           </td>
      </tr>
  </table>

  <table id="tblDocType" runat="server" class="tableIsys" style="width:80%; margin-left: 0px;" visible="false">
            <tr style="width:100%">
                <td id="Td1" class="test" colspan="4" runat="server" style="height:20px;">
                    <asp:label ID="lblformat" runat="server" Font-Bold="true">Download New Version</asp:label> 
                </td>
            </tr>
            <tr>
              <td class="formcontent" align="center">
                <asp:label ID="lblName" runat="server" Text="Document Name" style="color:Black"></asp:label>
              </td>
              <td class="formcontent" align="center">
                <asp:DropDownList ID="ddlName" DataTextField="ParamDesc" runat="server" CssClass="standardmenu" AutoPostBack="true"
                     TabIndex="11" Width="400px" OnSelectedIndexChanged="ddlName_SelectIndexChanged"></asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td colspan="2" align="center">
               <%--<div class="btn btn-xs btn-primary"><i class="fa fa-external-link"></i>--%>
                <asp:Button ID="btnView" runat="server" CssClass="standardbutton" Text="View Format" Width="100px"
                    Visible="true" OnClick="btnView_Click" /><%--</div>--%>
              </td>
           </tr>
       </table>

  <table id="tblMstDesign" runat="server" class="formtable2" style="width: 80%;" > <%--class="formtable"--%>
      <tr style="height: 20px;">
          <td colspan="4" class="test">
               <asp:Label ID="lblMstDocName" Text="Master Document Details" runat="server" Font-Bold="True"></asp:Label>
          </td>
      </tr>
      <tr style="height: 20px;">
         <td colspan="4">
            <asp:UpdatePanel ID="UpdGrid1" runat="server">
               <ContentTemplate>
                  <asp:GridView ID="dgMstDesign" runat="server" AllowSorting="True" CssClass="formtable"
                       PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                       RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="false"
                       Width="100%" Height="23px" onrowdatabound="dgMstDesign_RowDataBound">  
                     <Columns>
                         <asp:TemplateField SortExpression="" HeaderText="ColumnName">
                              <ItemTemplate>
                              <asp:TextBox ID="txtColName" runat="server" CssClass="standardtextbox" MaxLength="50"
                                   Width="100%" onkeypress="RestrictSpaceSpecial()" TabIndex="6"/>
                              </ItemTemplate>
                              <ItemStyle Width="30%" />
                         </asp:TemplateField>
                         <asp:TemplateField SortExpression="" HeaderText="Primary">
                              <ItemTemplate>
                              <asp:DropDownList ID="ddlIsPrim" runat="server" CssClass="standardtextbox" Width="100%" TabIndex="7"/>
                              </ItemTemplate>
                              <ItemStyle Width="25%" />
                         </asp:TemplateField>
                         <asp:TemplateField SortExpression="" HeaderText="DataType">
                              <ItemTemplate>
                              <asp:DropDownList ID="ddlDataType" runat="server" CssClass="standardtextbox" Width="100%" TabIndex="8" />
                              </ItemTemplate>
                              <ItemStyle Width="25%" />
                         </asp:TemplateField>
                         <asp:TemplateField SortExpression="" HeaderText="Length">
                              <ItemTemplate>
                              <asp:TextBox ID="txtLength" runat="server" CssClass="standardtextbox" MaxLength="35"
                                   Width="100%" onkeypress="Restrict()" TabIndex="9"/>
                              </ItemTemplate>
                              <ItemStyle Width="20%" />
                         </asp:TemplateField>
                     </Columns>
                     <RowStyle CssClass="sublinkodd"></RowStyle>
                     <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                     </PagerStyle>
                     <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                     <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                  </asp:GridView>
               </ContentTemplate>
             </asp:UpdatePanel>
         </td> 
      </tr>
      <tr>
        <td  colspan="4" align="center" style="height: 20px">
       <%-- <div class="btn btn-xs btn-primary"><i class="fa fa-plus"></i>--%>
             <asp:Button ID="btnIns" runat="server" CssClass="standardbutton" TabIndex="11"
                 Text="ADD" Width="114px" onclick="btnIns_Click" /><%--</div>--%><%--onclick="btnIns_Click"--%>
                  <%--<div class="btn btn-xs btn-primary"><i class="fa fa-times"></i>--%>
              <asp:Button ID="btnClr" runat="server" CssClass="standardbutton" TabIndex="11"
                 Text="Clear" Width="114px" onclick="btnClr_Click" /><%--</div>--%>
        </td>
      </tr>
  </table>

  <table id="tbldgMstDocDesign" runat="server" style="width: 80%;" class="formtable2">
        <tr style="height: 20px;">
            <td colspan="4" class="test">
                <asp:Label ID="lblMstDocDsgn" Text="Master Document Design" runat="server" Font-Bold="True" Width="700px"></asp:Label>
            </td>
        </tr>
        <tr style="height: 20px;">
            <td colspan="4">
                <asp:GridView ID="dgMstDocDesign" runat="server" AllowSorting="True" CssClass="formtable"
                              PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                              RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                              AllowPaging="True" Width="100%" PageSize="10" onrowdatabound="dgMstDocDesign_RowDataBound" 
                              onrowcommand="dgMstDocDesign_RowCommand" onrowdeleting="dgMstDocDesign_RowDeleting" 
                              onpageindexchanging="dgMstDocDesign_PageIndexChanging">
                     <Columns>
                        <asp:TemplateField SortExpression="Column1" HeaderText="DocType" Visible="false">
                             <ItemTemplate>
                             <asp:Label ID="lbl1" runat="server" Text='<%# Eval("DocType") %>'  Width="70" />
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Column2" HeaderText="ColumnName">
                             <ItemTemplate>
                             <asp:Label ID="lbl2" runat="server" Text='<%# Eval("ColumnName") %>'  Width="80" />
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Column3" HeaderText="DataType">
                             <ItemTemplate>
                             <asp:Label ID="lbl3" runat="server" Text='<%# Eval("Datatype") %>' Width="100" />
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Column4" HeaderText="Length">
                             <ItemTemplate>
                             <asp:Label ID="lbl4" runat="server" Text='<%# Eval("Length") %>' Width="70" />
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Column6" HeaderText="Isprimary">
                             <ItemTemplate>
                             <asp:Label ID="lbl6" runat="server" Text='<%# Eval("Isprimary") %>'  Width="100" />
                             </ItemTemplate>
                        </asp:TemplateField>                                        
                        <asp:TemplateField SortExpression="Column11" HeaderText="Createby" Visible="false">
                             <ItemTemplate>                                                
                             <asp:Label ID="lbl15" runat="server" Text='<%# Eval("Createby") %>' Width="70" />
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Column11" HeaderText="CreatedDTime" Visible="false">
                             <ItemTemplate>                                                
                             <asp:Label ID="lbl16" runat="server" Text='<%# Eval("CreatedDTime") %>' Width="70" />
                             </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField SortExpression="Column11" HeaderText="UpdateBy" Visible="false">
                            <ItemTemplate>                                                
                            <asp:Label ID="lbl17" runat="server" Text='<%# Eval("UpdateBy") %>' Width="70" />
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField SortExpression="Column11" HeaderText="UpdatedDTime" Visible="false">
                            <ItemTemplate>                                                
                            <asp:Label ID="lbl18" runat="server" Text='<%# Eval("UpdatedDTime") %>' Width="70" />
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                             <i class="fa fa-trash-o"></i>
                            <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" ForeColor="Red" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                            <ControlStyle Font-Underline="True" />
                            <FooterStyle Font-Underline="False" />
                       </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="sublinkodd"></RowStyle>
                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                    </PagerStyle>
                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
               </asp:GridView>
           </td> 
        </tr>
   </table>

  <table id="tblDownload" runat="server" style="width: 80%;" class="formtable2" visible="false">
            <tr style="height: 20px;">
                <td  class="test" colspan="3" align="left" style="border-collapse: separate; border-right-width: 0;height:20px;">
                    <asp:Label ID="lblDownload" runat="server" Text="Master Document Design" Font-Bold="true"></asp:Label> 
                    <span style="padding-left:80%;"></span>
                    <asp:Label ID="lblDPageInfo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="dgDownload" runat="server" CssClass="formtable" 
                        AutoGenerateColumns="false" AllowPaging="true"
                      PageSize="10" HorizontalAlign="Left"  AllowSorting="True" Width="100%" 
                        OnRowCommand="dgDownload_RowCommand" onrowediting="dgDownload_RowEditing"
                        OnRowDataBound="dgDownload_RowDataBound" onrowdeleting="dgDownload_RowDeleting">
                        <Columns>
                           <asp:TemplateField SortExpression="Doctype" HeaderText="Doctype" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDDoctype" runat="server" Text='<%# Eval("Doctype") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="ColumnName" HeaderText="ColumnName">
                                <ItemTemplate>
                                    <asp:Label ID="lblDColumnName" runat="server" Text='<%# Eval("ColumnName") %>' Width="100%"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30%" />
                            </asp:TemplateField>
                              <asp:TemplateField SortExpression="IsPrimary" HeaderText="IsPrimary">
                                <ItemTemplate>
                                    <asp:Label ID="lblDIsPrimary" runat="server" Text='<%# Eval("IsPrimary") %>' Width="100%"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20%" />
                            </asp:TemplateField>
                             <asp:TemplateField SortExpression="DataType" HeaderText="DataType">
                                <ItemTemplate>
                                    <asp:Label ID="lblDDataType" runat="server" Text='<%# Eval("DataType") %>' Width="100%"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="Length" HeaderText="Length">
                                <ItemTemplate>
                                    <asp:Label ID="lblDLength" runat="server" Text='<%# Eval("Length") %>' Width="100%"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                 <i class="fa fa-edit"></i>
                                     <asp:LinkButton ID="DEditBtn"  runat="server" Text="Edit" CommandName="Edit" ForeColor="Green"/>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                <ControlStyle Font-Underline="True" />
                                <FooterStyle Font-Underline="False" />
                            </asp:TemplateField>
                             <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                 <i class="fa fa-trash-o"></i>
                                     <asp:LinkButton ID="DEdeleteBtn" runat="server" Text="Delete" CommandName="Delete" ForeColor="Red"/>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                <ControlStyle Font-Underline="True" />
                                <FooterStyle Font-Underline="False" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="sublinkodd" />
                        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True"></PagerStyle>
                        <HeaderStyle CssClass="portlet blue" ForeColor="white" Font-Bold="true"></HeaderStyle>
                        <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 20px">
                <%--<div class="btn btn-xs btn-primary"><i class="fa fa-plus"></i>--%>
                    <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" Text="Add" 
                        Width="114px"  onclick="btnAdd_Click"  /><%--</div>--%>
                </td>
            </tr>
        </table>

  <table id="tblButton" runat="server" style="width: 80%;" class="formtable2">
        <tr>
           <td colspan="4" align="center" style="height: 20px">
         <%--  <div class="btn btn-xs btn-primary"><i class="fa fa-check-square-o"></i>--%>
                <asp:Button ID="btnFinish" runat="server" CssClass="standardbutton" TabIndex="12"
                            Text="Finish" Width="114px" onclick="btnFinish_Click" Enabled="false" /> <%--</div>--%>
                          <%--  <div class="btn btn-xs btn-primary"><i class="fa fa-times"></i>--%>
                <asp:Button ID="btncancel" runat="server" CssClass="standardbutton" TabIndex="13"
                            Text="Cancel" Width="114px" onclick="btnCancel_Click" Visible="false"  /><%-- </div>--%>
           </td>
        </tr>
  </table>

</center>

<asp:HiddenField ID="hdnGridRowId" runat="server" />

<asp:HiddenField ID="hdnColumnName" runat="server" />
<asp:HiddenField ID="hdnIsPrimary" runat="server" />
<asp:HiddenField ID="hdnDataType" runat="server" />
<asp:HiddenField ID="hdnLength" runat="server" />

        <%--</div>--%>
        <%--For Displaying Information Pop-up Start--%>
        <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
           BorderWidth="2px" class="modalpopupmesg" Width="309px" Height="124px">
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
            <center style="height: 36px">
                 <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="40px" />
            </center>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl_popup"
            BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
            DropShadow="true" OkControlID="btnok" Y="100">
        </ajaxToolkit:ModalPopupExtender>
        <%--For Displaying Information Pop-up End--%>

</asp:Content>