<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MstTblDesign.aspx.cs" Inherits="Application_INSC_Recruit_MstTblDesign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script language="javascript" type="text/javascript">
    //loading image icon
    function LdWait(delay) {
        //debugger;
        document.getElementById("ctl00_ContentPlaceHolder1_divLoader").style.display = 'block';
        setTimeout("RemoveLoading12()", delay);
    }

    function RemoveLoading12() {
        //debugger;
        //hide loading status...
        document.getElementById("ctl00_ContentPlaceHolder1_divLoader").style.display = 'none';

    }

    function funMandatory() {
        if (document.getElementById("ctl00_ContentPlaceHolder1_txtDoctype").value == "") {
            RemoveLoading12();
            alert("Document Type is mandatory.");
            document.getElementById("ctl00_ContentPlaceHolder1_txtDoctype").focus();
           
            return false;
        }

        if (document.getElementById("ctl00_ContentPlaceHolder1_txtDocDesc").value == "") {
            
            alert("Document Description is mandatory.");
            document.getElementById("ctl00_ContentPlaceHolder1_txtDocDesc").focus();
            return false;
            var strContent = "ctl00_ContentPlaceHolder1";
            var id = strContent.dgMstDesign.Rows(Me.dgMstDesign.EditItemIndex).FindControl("txtColName").ClientId
            RemoveLoading12();
        }

        if (document.getElementById("ctl00_ContentPlaceHolder1_txtShrtDocName").value == "") {
            RemoveLoading12();
            alert("Document short code is mandatory.");
            document.getElementById("ctl00_ContentPlaceHolder1_txtShrtDocName").focus();
            return false;
        }

        if (document.getElementById("ctl00_ContentPlaceHolder1_txtColcnt").value == "") {
            RemoveLoading12();
            alert("Column count is mandatory.");
            document.getElementById("ctl00_ContentPlaceHolder1_txtColcnt").focus();
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
        if ((event.keyCode == 33 || event.keyCode == 34 || event.keyCode == 35 || event.keyCode == 36 || event.keyCode == 37 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40 || event.keyCode == 41 || event.keyCode == 42 || event.keyCode == 43 || event.keyCode == 44 || event.keyCode == 45 || event.keyCode == 46 || event.keyCode == 47 || event.keyCode == 64)) {
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

    function StartProgressBar() {
        // debugger;
        var myExtender = $find('ProgressBarModalPopupExtender');
        myExtender.show();
        return true;
    }

    //shreela

    function AlertMsgs(msgs) {
        alert(msgs);
    }

</script>

<asp:ScriptManager ID="SmMstdesign" runat="server">
</asp:ScriptManager>

        <table id="tblMstDesign" runat="server" style="width: 100%;" class="tableIsys"> 
            <tr style="height: 20px;">
                <td colspan="4" class="test">
                    <asp:Label ID="lblMstDocDesign" runat="server" Font-Bold="True" Width="700px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formcontent" style="width: 20%;">
                    <span style="color: red">
                    <asp:Label ID="lblUDoctype" runat="server" Style="color: black"></asp:Label>*</span>
                </td>
                <td class="formcontent" style="width: 30%;">
                    <asp:TextBox ID="txtDoctype" runat="server" CssClass="standardtextbox" MaxLength="8"
                        TabIndex="1"  Width="201px"  BackColor="#FFFFB2"></asp:TextBox> <%--BackColor="LightGray" ReadOnly="True" Enabled="false"--%>
                        <asp:HiddenField ID="hdntxtDoctype" runat="server" />
                </td>
                <td class="formcontent" style="width: 20%;">
                    <span style="color: red">
                        <asp:Label ID="lblDecDesc" runat="server" Style="color: black"></asp:Label>*</span>
                </td>
                <td class="formcontent" style="width: 30%;">
                    <asp:TextBox ID="txtDocDesc" runat="server" width="201px" CssClass="standardtextbox" 
                      TabIndex="2" BackColor="#FFFFB2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formcontent" style="width: 20%;">
                    <span style="color: red">
                        <asp:Label ID="lblshrtDocName" runat="server" Style="color: black"></asp:Label>*</span>
                </td>
                <td class="formcontent" style="width: 30%;">
                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                     <span style="color: red">
                    <asp:TextBox ID="txtShrtDocName" width="201px" runat="server" CssClass="standardtextbox" MaxLength="7"
                         onChange="javascript:this.value=this.value.toUpperCase();" BackColor="#FFFFB2"
                         TabIndex="3" ></asp:TextBox>

                       <%--shreela--%>

                            <asp:Label ID="lblshrt" runat="server" text="(eg.UAAAAAA)" style="color: red"></asp:Label></span>
                           <%-- shreela--%>
                   
                        </ContentTemplate>
                       </asp:UpdatePanel>
                </td>
                <td class="formcontent" style="width: 20%;">
                <span style="color: red">
                    <asp:Label ID="lblColcnt" runat="server" Style="color: black"></asp:Label>*</span>
                    
                </td>
                <td class="formcontent" style="width: 30%;">
                <asp:TextBox ID="txtColcnt" runat="server" width="201px" CssClass="standardtextbox" 
                          TabIndex="4" onkeypress="Restrict()" BackColor="#FFFFB2"></asp:TextBox>
                  <asp:HiddenField ID="hdnColcnt" runat="server" />     
                </td>
            </tr>
             <tr>
                <td class="formcontent" style="width: 20%;">
                    <span style="color: red"><asp:Label ID="lblFileSize" runat="server" Text="File Size" Style="color: black"></asp:Label>*</span>
                </td>
                <td>
                     <asp:UpdatePanel ID="upldFileSize" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlFileSize" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                    Width="100px" BackColor="#FFFFB2" TabIndex="5">
                                </asp:DropDownList>&nbsp;&nbsp;
                                <asp:Label ID="lblKB" runat="server" text="(In KB's)" style="color: red"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
             <td  colspan="2"  style="height: 20px;" align="right">
            <%-- <div class="btn btn-xs btn-primary" style="width:130px;"><i class="fa fa-flash"></i>--%>
                 <asp:Button ID="btnInsert" runat="server" CssClass="standardbutton" TabIndex="6"
                        Text="Start Design" Width="114px" onclick="btnInsert_Click" OnClientClick="LdWait(100000)"/><%--</div>--%>
             </td>
             <td colspan="2" align="left" style="height: 20px;">
                 <div id="divloader" runat="server" style="display:none;">
                    &nbsp;&nbsp; <img id="Img1" alt="" src="../../../app_themes/isys/images/spinner.gif" runat="server" /> Loading...
                    </div>
            </td>
          </tr>
        </table>

        <table id="tblDocType" runat="server" class="tableIsys" style="width:100%; margin-left: 0px;" visible="false">
            <tr style="width:100%">
                <td id="Td1" class="test" colspan="4" runat="server" style="height:20px;">
                    <asp:label ID="lblformat" runat="server" Font-Bold="true">Upload New Version</asp:label> 
                </td>
            </tr>
            <tr>
              <td class="formcontent" align="center">
                <asp:label ID="lblName" runat="server" Text="Document Name" style="color:Black"></asp:label>
              </td>
              <td class="formcontent" align="center">
                  <%--<asp:UpdatePanel ID="updName" runat="server">
                      <ContentTemplate>--%>
                            <asp:DropDownList ID="ddlName" DataTextField="ParamDesc" runat="server" CssClass="standardmenu" AutoPostBack="true"
                             TabIndex="11" Width="400px" OnSelectedIndexChanged="ddlName_SelectIndexChanged"></asp:DropDownList>
                    <%--  </ContentTemplate>
                  </asp:UpdatePanel>--%>
              </td>
            </tr>
            <tr>
              <td colspan="2" align="center">
              <%-- <asp:UpdatePanel ID="updView" runat="server">
                      <ContentTemplate>--%>
                        <%-- <div class="btn btn-xs btn-primary" style="width:120px;">--%>
                    <%-- <i class="fa fa-external-link"></i> --%>   
                    <asp:Button ID="btnView" runat="server" CssClass="standardbutton" Text="View Format" Width="100px"
                                  Visible="true" OnClick="btnView_Click" /><%--</div>--%>
                    <%--</ContentTemplate>
                  </asp:UpdatePanel>--%>
              </td>
           </tr>
       </table>

        <table id="tblEditDesign" runat="server" style="width: 100%;" class="formtable2" visible="false"> <%--class="formtable"--%>
           <tr style="height: 20px;">
                <td colspan="4" class="test">
                    <asp:Label ID="lblMstDocName" Text="Master Document Details" runat="server" Font-Bold="True" Width="700px"></asp:Label>
                </td>
            </tr>
            <tr style="height: 20px;">
               <td colspan="4">
               <asp:UpdatePanel ID="UpdGrid1" runat="server">
                        <ContentTemplate>
                 <asp:GridView ID="dgMstDesign" runat="server" AllowSorting="True" CssClass="formtable"
                                    PagerStyle-HorizontalAlign="Center" 
                                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="false" 
                                    Width="100%" PageSize="1" 
                                    onrowdatabound="dgMstDesign_RowDataBound" 
                                    Height="23px">
                                    <Columns>
                                        <asp:TemplateField SortExpression="" HeaderText="ColumnName">
                                            <ItemTemplate><asp:TextBox ID="txtColName" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                            Width="100%" onkeypress="RestrictSpaceSpecial()"/>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="Primary">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlIsPrim" runat="server" CssClass="standardtextbox" Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="DataType">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlDataType" runat="server" CssClass="standardtextbox" Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="Length">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLength" runat="server" CssClass="standardtextbox" MaxLength="35"
                                                            Width="100%" onkeypress="Restrict()" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="Mandatory">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlIsMandatory" runat="server" CssClass="standardtextbox" Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>

                                       <asp:TemplateField SortExpression="" HeaderText="Verif Req" >
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlVerifReq" OnSelectedIndexChanged="ddlVerifReq_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="standardtextbox" Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="8%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="Permissible value">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPermisibleValues" runat="server" CssClass="standardtextbox" MaxLength="35"
                                                            Width="100%" /><br />
                                            </ItemTemplate>
                                            <ItemStyle Width="13%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="Database">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlDB" runat="server" OnSelectedIndexChanged="ddlDB_SelectedIndexChanged" CssClass="standardtextbox" AutoPostBack="true" Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="13%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="Table">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddltbl" runat="server" OnSelectedIndexChanged="ddltbl_SelectedIndexChanged" CssClass="standardtextbox" AutoPostBack="true" Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="13%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="" HeaderText="Column">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlCol" runat="server" CssClass="standardtextbox" Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="13%" />
                                        </asp:TemplateField>

                                       <%-- <asp:TemplateField SortExpression="" HeaderText="where">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtwhere" runat="server" CssClass="standardtextbox" MaxLength="35"
                                                            Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>--%>
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
             <%--<div class="btn btn-xs btn-primary" style="width:110px;">
                     <i class="fa fa-plus"></i>--%>
                                <asp:Button ID="btnIns" runat="server" CssClass="standardbutton" TabIndex="11"
                                    Text="Add" Width="114px" onclick="btnIns_Click"/><%--</div>--%>
                                     <span style="padding-left:3px;"></span>
                <%-- <div class="btn btn-xs btn-primary" style="width:110px;">
                     <i class="fa fa-times"></i> --%>              
                                <asp:Button ID="btnClr" runat="server" CssClass="standardbutton" TabIndex="11"
                                    Text="Clear" Width="114px" onclick="btnClr_Click" /><%--</div>--%>
            </td>
            </tr>
                        
        </table>

        <table id="tbl_grid" class="test table-condensed" style="width: 100%;" runat="server" visible="false">
                <tr id="tr_grid" align="left" style="visibility:hidden">
                    <td align="left" class="test" style="width:100%;">
                    <input runat="server" class="standardbutton" type="button" value="-" id="btnUploadDtls"  
                        style="width:20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearchDetails','ctl00_ContentPlaceHolder1_btnUploadDtls');"/> 
                    <asp:Label ID="lblNotes" runat="server"  Text="Notes" Font-Bold="true"></asp:Label>
                    </td>

                </tr>
       </table>

        <div id="divSearchDetails" runat="server" style="display: block;">
                <table id="tblnotes" runat="server" width="100%" visible="false">
                <tr>
                        <td nowrap="nowrap" align="left" class="test" style="width: 20%;">
                         Description
                        </td>
                        <td nowrap="nowrap" align="left" class="test" style="width: 30%;" colspan="3">
                         Values
                        </td>
                       
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left"  class="formcontent" style="width: 20%;">
                          <span style="color: red">Permissible Values</span> 
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;" colspan="3">
                        <span style="color: red">Values should be comm (,) specific</span>
                        </td>
                       
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="formcontent" 
                            style="width: 20%; height: 18px;">
                           <span style="color: red">Verification Required</span>
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" 
                            style="width: 30%; height: 18px;" colspan="3">
                           <span style="color: red">0 (Not Required)</span>
                        </td>
                       
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%;">
                           
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;">
                        <span style="color: red">1 (Check Permissible value)</span>
                        </td>
                        
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%;">
                         
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;" colspan="3">
                        <span style="color: red">2 (Chk verify table)</span>
                        </td>
                       
                    </tr>
                </table>
            </div>
        
        <table id="tbldgMstDocDesign" runat="server" class="formtable2" style="width: 100%;" visible="false" > <%--class="formtable"--%>
            <tr style="height: 20px;">
                <td colspan="4" class="test">
                    <asp:Label ID="lblMstDocDsgn" Text="Master Document Design" runat="server" Font-Bold="True" Width="700px"></asp:Label>
                </td>
            </tr>
            <tr style="height: 20px;">
               <td colspan="4">
                  <asp:GridView ID="dgMstDocDesign" runat="server" AllowSorting="True" CssClass="formtable"
                                    PagerStyle-HorizontalAlign="Center" 
                       PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" 
                                    Width="100%" PageSize="10" 
                       onrowdatabound="dgMstDocDesign_RowDataBound" 
                       onrowcommand="dgMstDocDesign_RowCommand" 
                       onrowdeleting="dgMstDocDesign_RowDeleting" onpageindexchanging="dgMstDocDesign_PageIndexChanging">
                                    <Columns>
                                       
                                        <%--<asp:TemplateField SortExpression="Column12" HeaderText="SeqNo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseqno" runat="server" Text='<%# Eval("Column12") %>'   Width="50" />
                                                </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField SortExpression="Column1" HeaderText="DocType" Visible="false">
                                            <ItemTemplate>
                                               
                                                <asp:Label ID="lbl1" runat="server" Text='<%# Eval("DocType") %>'  Width="70" />
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column2" HeaderText="Column Name">
                                            <ItemTemplate>
                                               
                                                <asp:Label ID="lbl2" runat="server" Text='<%# Eval("ColumnName") %>'  Width="80" />
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField SortExpression="Column6" HeaderText="Isprimary">
                                            <ItemTemplate>
                                               
                                                <asp:Label ID="lbl6" runat="server" Text='<%# Eval("Isprimary") %>'  Width="100" />
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
                                        <asp:TemplateField SortExpression="Column5" HeaderText="XLHDR" Visible="false">
                                            <ItemTemplate>
                                               
                                                <asp:Label ID="lbl5" runat="server" Text='<%# Eval("XLHDR") %>'  Width="100" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                         <asp:TemplateField SortExpression="Column7" HeaderText="Mandatory">
                                            <ItemTemplate>
                                                
                                                <asp:Label ID="lbl7" runat="server" Text='<%# Eval("Mandatory") %>' Width="80" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField SortExpression="Column9" HeaderText="VerifReq">
                                            <ItemTemplate>
                                                
                                                <asp:Label ID="lbl9" runat="server" Text='<%# Eval("VrifReq") %>' Width="100" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column8" HeaderText="PermissibleValues">
                                            <ItemTemplate>
                                                
                                                <asp:Label ID="lbl8" runat="server" Text='<%# Eval("PermissibleValues") %>' Width="100" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        <asp:TemplateField SortExpression="Column10" HeaderText="VerifDb">
                                            <ItemTemplate>
                                                
                                                <asp:Label ID="lbl10" runat="server" Text='<%# Eval("VrifDb") %>' Width="100" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField SortExpression="Column11" HeaderText="VerifTbl">
                                            <ItemTemplate>
                                                
                                                <asp:Label ID="lbl11" runat="server" Text='<%# Eval("VerifTbl") %>' Width="70" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="Column11" HeaderText="VerifTblColumn">
                                            <ItemTemplate>                                                
                                                <asp:Label ID="lbl12" runat="server" Text='<%# Eval("VerifTblColumn") %>' Width="70" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField SortExpression="Column11" HeaderText="VerifWhereCond">
                                            <ItemTemplate>                                                
                                                <asp:Label ID="lbl13" runat="server" Text='<%# Eval("VerifWhereCond") %>' Width="70" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="Status" Visible="false">
                                            <ItemTemplate>                                                
                                                <asp:Label ID="lbl14" runat="server" Text='<%# Eval("Status") %>' Width="70" />
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
                                          <div style="width:100%;"><i class="fa fa-trash-o"></i>
                                            <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" ForeColor="Red" /></div>
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
       <%-- <asp:UpdatePanel ID="updMsttblDesign" runat="server">
             <ContentTemplate>--%>
        
                  <table id="tblUpload" runat="server" style="width: 100%;" class="formtable2" visible="false">
            <tr style="height: 20px;">
                <td  class="test" colspan="3" align="left" style="border-collapse: separate; border-right-width: 0;height:20px;">
                    <asp:Label ID="lblUpload" runat="server" Text="Master Document Design" Font-Bold="true"></asp:Label> 
                    <span style="padding-left:70%;"></span>
                    <asp:Label ID="lblUPageInfo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:GridView ID="dgUpload" runat="server" AllowSorting="True" CssClass="formtable"
                       HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" 
                         Width="100%" PageSize="10" onrowcommand="dgUpload_RowCommand" 
                         onrowdatabound="dgUpload_RowDataBound" 
                         onrowdeleting="dgUpload_RowDeleting" onrowediting="dgUpload_RowEditing" >
                              <Columns>
                                        <asp:TemplateField  HeaderText="DocType" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUDocType" runat="server" Text='<%# Eval("DocType") %>'  />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Column Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUColumnName" runat="server" Text='<%# Eval("ColumnName") %>'  Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Isprimary">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUIsprimary" runat="server" Text='<%# Eval("Isprimary") %>'  Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DataType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUDataType" runat="server" Text='<%# Eval("Datatype") %>' Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Length">
                                            <ItemTemplate>
                                                <asp:Label ID="lblULength" runat="server" Text='<%# Eval("Length") %>' Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="XLHDR" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUXLHDR" runat="server" Text='<%# Eval("XLHDR") %>'  />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                         <asp:TemplateField HeaderText="Mandatory">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUMandatory" runat="server" Text='<%# Eval("MandatoryFlag") %>' Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VerifReq">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUVrifReq" runat="server" Text='<%# Eval("VerifReq") %>' Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PermissibleValues">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUPermissibleValues" runat="server" Text='<%# Eval("PremissibleValues") %>' Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Database">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUVrifDb" runat="server" Text='<%# Eval("VerifDb") %>' Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="14%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Table">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUVerifTbl" runat="server" Text='<%# Eval("VerifTbl") %>' Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="14%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Column">
                                            <ItemTemplate>                                                
                                                <asp:Label ID="lblUVerifTblColumn" runat="server" Text='<%# Eval("VerifTblColumn") %>' Width="100%" />
                                            </ItemTemplate>
                                             <ItemStyle Width="14%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="false">
                                            <ItemTemplate>
                                              <div style="width:100%;"><i class="fa fa-edit"></i>
                                                <asp:LinkButton ID="EditBtn" runat="server" Text="Edit" ForeColor="Green" CommandName="Edit" CommandArgument='<%# Eval("ColumnName") %>'/></div>
                                            </ItemTemplate>
                                             <ItemStyle Width="3%" />
                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                        <ControlStyle Font-Underline="True" />
                                        <FooterStyle Font-Underline="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                         <div style="width:100%;"><i class="fa fa-trash-o"></i>
                                            <asp:LinkButton ID="DeleteBtn" runat="server" Text="Delete" CommandName="Delete" ForeColor="Red" />
                                        </ItemTemplate>
                                         <ItemStyle Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                        <ControlStyle Font-Underline="True" />
                                        <FooterStyle Font-Underline="False" />
                                        </asp:TemplateField>
                                    </Columns>
                              <RowStyle CssClass="sublinkodd"></RowStyle>
                              <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                              </PagerStyle>
                              <HeaderStyle CssClass="test" ForeColor="Navy"></HeaderStyle>
                              <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                      </asp:GridView>
                  </td>
            </tr>
            <tr>
                <td align="center" style="height: 20px">
                 <%--<div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-plus"></i>--%>
                    <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" Text="Add" 
                        Width="114px"  onclick="btnAdd_Click"  /><%--</div>--%>
                </td>
            </tr>
        </table>

                  <table id="tblButton" runat="server" class="formtable">
            <tr>
                 <td  colspan="4" align="center" style="height: 20px">
                 <%-- <div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-lightbulb-o"></i>--%>
                     <asp:Button ID="btnConfirm" runat="server" CssClass="standardbutton" TabIndex="11"
                          Text="Confirm" Width="114px" onclick="btnConfirm_Click"/><%--</div>--%>
                            <span style="padding-left:3px;"></span>
                          <%--<div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-lightbulb-o"></i>--%>
                     <asp:Button ID="btnFinish" runat="server" CssClass="standardbutton" TabIndex="11"
                          Text="Finish" Width="114px" onclick="btnFinish_Click"/><%--</div>--%>
                             <span style="padding-left:3px;"></span>
                    <%-- <div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-times"></i>--%>
                      <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" TabIndex="11"
                          Text="Cancel" Width="114px" onclick="btnCancel_Click"/><%--</div>--%>
                </td>
            </tr>
        </table>

             <%--</ContentTemplate>
             <Triggers><asp:AsyncPostBackTrigger ControlID="ddlName" EventName="SelectedIndexChanged" /></Triggers>
             <Triggers><asp:AsyncPostBackTrigger ControlID="btnView" EventName="Click" /></Triggers>
        </asp:UpdatePanel>--%>
        <asp:HiddenField ID="hdnGridRowId" runat="server" />

         <asp:HiddenField ID="hdnColumnName" runat="server" />
         <asp:HiddenField ID="hdnIsprimary" runat="server" />
         <asp:HiddenField ID="hdnDataType" runat="server" />
         <asp:HiddenField ID="hdnLength" runat="server" />
         <asp:HiddenField ID="hdnMandatory" runat="server" />
         <asp:HiddenField ID="hdnVrifReq" runat="server" />
         <asp:HiddenField ID="hdnPermissibleValues" runat="server" />
         <asp:HiddenField ID="hdnVrifDb" runat="server" />
         <asp:HiddenField ID="hdnVerifTbl" runat="server" />
         <asp:HiddenField ID="hdnVerifTblColumn" runat="server" />
        
        <%--For Displaying Information Pop-up Start--%>
   
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="309px" Height="127px">
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
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="40px" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl_popup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--For Displaying Information Pop-up End--%>
   
</asp:Content>