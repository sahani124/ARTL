<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UsrSu.aspx.cs" 
    Inherits="Application_Admin_UsrSu" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

      <%-- start Added by sanoj 29092022--%>

    
   
    <link href="../../KMI Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

     <%-- endded by sanoj 29092022--%>


     <%--<link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    
    <script src="../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <%-- <atlas:ScriptManager ID="scriptMgr" EnablePartialRendering="true" runat="server" />--%>
     
    <script type="text/javascript" language="javascript">


        function fncInputNumericValuesOnly() {
            debugger;
            if (!(event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) {
                event.returnValue = false;
            }
        }


        function ShowReqDtl(divName, btnName) {
            //debugger;
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
        function ClearSearch() {
            var answer = confirm("jump to another javascript page")
            if (answer) {
                alert("yes");
                return true;
            }
            else {
                alert("no");
                return false;
            }
        }

        function checkRadio(frmName, rbGroupName) {
            var radios = document[frmName].elements[rbGroupName];
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].checked) {
                    return true;
                }
            }
            return false;
        }

        function rdbValidate() {
            //debugger;
            var RB1 = document.getElementById("<%=ddlInUserType.ClientID%>") || document.getElementById("<%=ddlInUserType.ClientID%>") || document.getElementById("<%=ddlEXUserType.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    isChecked = true;
                    //break;
                }

            }

            return isChecked;
        }




        function f_FormValidate() {
            if (!rdbValidate()) {
                alert("Please Select User Types");
                return false;
            }

            if (document.getElementById("<%=cboUserRole.ClientID %>").value == '') {
                alert("Please mention User Role.");
                document.getElementById("<%=cboUserRole.ClientID %>").focus();
                return false;
            }
            return true;
        }
        function OnTreeClick(evt) {
            //debugger;
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;

            // upllaod download sanction part start
            var ModuleName = src.parentNode.innerText;
            var strUserID = "<%=userid%>";
            //alert(str);
            if (ModuleName == "File Upload" || ModuleName == "File Download") {
                var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
                if (isChkBoxClick) {
                    if (src.checked == true) {
                        document.getElementById("divUserSanc").style.display = "block";
                        document.getElementById("ctl00_ContentPlaceHolder1_ifrmUserSanc").src = "../ISys/Recruit/UserSanction.aspx?UserID=" + strUserID + "&Mode=" + ModuleName + "";
                    }
                    else if (src.checked == false) {
                        document.getElementById("divUserSanc").style.display = "none";
                    }
                }
            }
            else {
                document.getElementById("divUserSanc").style.display = "none";
            }
            // upllaod download sanction part end


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

     <style type="text/css">
         .clscenter{
           text-align:center!important;
         }
         .gridview th a{
             padding:6px !important;
         }
      </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            
            
             
              
            
              <div class="col-sm-12" style="text-align: left;margin-left: 2%; margin-right: 2%;">
                            <ul class="nav nav-tabs" style="margin-bottom:-30px;width: 1171px;">
                            <li class="active">
                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="10px" OnClick="v1_click" BackColor="#034ea2" ForeColor="White">User Details</asp:LinkButton>
                                </li>
                            <li class="active">
                            <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="10px" OnClick="v3_click" BackColor="#034ea2" ForeColor="White">Service Sanctioning</asp:LinkButton>
                                </li>
                                </ul>
                           
                  </div>
            <br />  <br />  <br />
               <div class="card PanelInsideTab" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                <%--     <div >
                    <td>&nbsp;
                    </td>
                </div>--%>
                <div class="panel-heading" runat="server" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnMap');return false;">
                    <div class="row">
                        
                        <div class="col-sm-10" style="text-align: left">
                           
              
                            <asp:Label ID="L1" runat="server" Font-Size="18px" >User Details</asp:Label>
                                
                            
                            <asp:Label ID="L3" runat="server" Visible="false" Font-Size="18px" >Service Sanctioning</asp:Label>
                                
                          </div>
                            <div class="col-sm-2">
                    
                            <span id="btnMap" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                      
                               
                             </div>
                            
                    </div>
                </div>

                <div id="divSearch" runat="server" style="display: block;" class="panel-body">
                    <div class="row" style="margin-left: 2%; margin-right: 2%">
                        <div class="col-sm-12">

                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <div class="tab-content">
                                
                            <asp:View ID="View1" runat="server">

                           <div>
                                    <div class="row ">
                                    <div class="col-sm-4" style="text-align: left;color: #00cccc; top: 0px; left: 0px;">
                                        <asp:Label Font-Size="18px" ID="lblTitle" style="margin-right:62%;" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-4" style="text-align: left;color:#00cccc;">
                                        <asp:Label  Font-Size="18px" ID="lblDplUserId" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-4" style="text-align: left;color: #00cccc;">
                                        <asp:Label  Font-Size="18px" ID="lblModVer" runat="server" Text=""></asp:Label>
                                    </div>
                                  </div>
                                
                                   

                                    <div class="row rowspacing">
                                 <div class="col-sm-4" style="text-align: left">
                                      <asp:Label ID="lblUserName" CssClass="control-label" runat="server"></asp:Label>
                                          
                                        
                                            <asp:TextBox ID="txtUserName"  runat="server" onChange="javascript:this.value=this.value.toUpperCase();" CssClass="form-control mandatory mandatory"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please insert user name." Display="Dynamic"
                                                Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtUserName" SetFocusOnError="true" ValidationGroup="NewsUserGroup"></asp:RequiredFieldValidator>
                                     </div>
                                   <div class="col-sm-4" style="text-align: left">
                                       <asp:Label ID="lblUserID" runat="server" CssClass="control-label"></asp:Label>
                                        
                                            <div class="input-group" >
                                               
                                            <asp:TextBox ID="txtUserID" runat="server"  onChange="javascript:this.value=this.value.toUpperCase();" CssClass="form-control mandatory"></asp:TextBox>
                                                <span class="input-group-btn">
                                            <asp:LinkButton ID="btnCheckID" runat="server" OnClick="btnCheckID_Click" Text="Check ID"  style="width:100%;margin-left: 5px;height: 35px;" CausesValidation="true" CssClass="btn btn-success" ValidationGroup="checkUserGroup">
                                                           <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Check ID
                                            </asp:LinkButton>
                                                </span>
                                                </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please insert a user ID." Display="Dynamic"
                                                Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtUserID" SetFocusOnError="true" ValidationGroup="checkUserGroup"></asp:RequiredFieldValidator>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please insert a user ID." Display="Dynamic"
                                                Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtUserID" SetFocusOnError="true" ValidationGroup="NewsUserGroup"></asp:RequiredFieldValidator>

                                            <asp:RegularExpressionValidator ID="regExpValUserName" runat="server" ControlToValidate="txtUserID"
                                                Display="Dynamic" ErrorMessage="Alphanumeric only!" SetFocusOnError="True" ValidationExpression="\w*\d*" ValidationGroup="checkUserGroup"></asp:RegularExpressionValidator>
                                            
                                            <asp:Label ID="lblerror" runat="server" CssClass="msgerror" Font-Size="8pt" Visible="False"></asp:Label>
                                            <asp:Label ID="lblSuccess" runat="server" CssClass="msgsuccess" Font-Size="8pt" Visible="False"></asp:Label>
                                            
                                     </div>
                                   <div class="col-sm-4" style="text-align: left">
                                        <asp:Label ID="lblEmailID" runat="server" CssClass="control-label" Text="Email ID"></asp:Label>
                                      
                                            <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control mandatory"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please insert Email ID." Display="Dynamic"
                                                Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtEmailID" SetFocusOnError="true" ValidationGroup="NewsUserGroup"></asp:RequiredFieldValidator>
                                     </div>

                               </div>
                                    <div class="row rowspacing">
                                        <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="lblStatus" runat="server" CssClass="control-label"></asp:Label>
                                             <asp:DropDownList ID="cboStatus" runat="server" DataSourceID="SqlDataSource1" DataTextField="paramDesc01"
                                                DataValueField="paramValue" CssClass="form-control mandatory">
                                            </asp:DropDownList>
                                        </div>
                                       <div class="col-sm-4" style="text-align: left;">
                                            <asp:Label ID="lblPwd" runat="server" CssClass="control-label"></asp:Label>
                                       
                                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="form-control mandatory"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="lblConfirmPwd" runat="server" CssClass="control-label"></asp:Label>
                                        
                                            <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" CssClass="form-control mandatory"></asp:TextBox>
                                        </div>


                                    </div>
                                   
                                    <div class="row rowspacing">
                                        <div class="col-sm-4" style="text-align: left;">
                                            <asp:Label ID="lblUserRole" runat="server" CssClass="control-label" Text="User Access Role"></asp:Label>
                                          
                                        
                                            <asp:DropDownList ID="cboUserRole" runat="server" CssClass="form-control mandatory">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="lblLanguage" runat="server" CssClass="control-label"></asp:Label>
                                       
                                            <asp:DropDownList ID="cboLanguage" runat="server" CssClass="form-control mandatory">
                                                <asp:ListItem Value="01">English</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4" style="text-align: left;">
                                            <asp:Label ID="lblUsers" runat="server" CssClass="control-label" Text="User Types"></asp:Label>
                                       

                                            <asp:RadioButtonList ID="rdbInter" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbInter_SelectedIndexChanged">
                                                <asp:ListItem Value="I" Text="Internal" style="margin-right: 7px;"></asp:ListItem>
                                                <asp:ListItem Value="E" Text="External"></asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>
                                    </div>
                                    <div class="row rowspacing">
                                      
                                        <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Department"> </asp:Label>
                                       
                                            <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control mandatory">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4" style="text-align: left;">
                                            <asp:Label ID="LblRoles" runat="server" CssClass="control-label" Text="User Role"></asp:Label>
                                            
                                        
                                            <asp:DropDownList ID="ddlInUserType" runat="server" RepeatDirection="Horizontal" Visible="false" CssClass="form-control mandatory">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlEXUserType" runat="server"
                                                RepeatDirection="Horizontal" Visible="false"
                                                CssClass="form-control mandatory" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlEXUserType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMemberRole" runat="server"
                                                Visible="true" CssClass="form-control mandatory" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlMemberRole_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                         <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="lblAuthType" runat="server" CssClass="control-label" Text="Authentication Type"></asp:Label>
                                       

                                            <asp:RadioButtonList ID="rdbAuthType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                                <asp:ListItem Value="D" style="margin-right: 7px;">&nbsp;Database</asp:ListItem>
                                                <asp:ListItem Value="A">&nbsp;AD</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>
                                    </div>
                                   
                                    <div id="trHierarchy" runat="server" style="margin-top:13px;" visible="false">
                                        <div class="panel-heading"  runat="server" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_UserOtherDtls','btnMap1');return false;">
                                            <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                               <%-- <input runat="server" type="button" class="standardlink" value="-" id="btnprsnldtlscollapse"
                                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_UserOtherDtls', 'ctl00_ContentPlaceHolder1_btnMap1');" />--%>
                                                
                                                <asp:Label ID="lblPersonalPart" runat="server" Font-Size="18px" Text="User Other Details" style="float:left;" ></asp:Label>
                                            </div>
                                                <div class="col-sm-2"> 
                                                    <span id="btnMap1" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                                                </div>
                                                </div>
                                           </div>
                                       
                                            <div id="UserOtherDtls" runat="server">
                                                <div class="row rowspacing">
                                                <div class="col-sm-4">
                                                    <asp:Label ID="lblSapCode" runat="server" CssClass="control-label" Text="Employee Code"></asp:Label>
                                               
                                                    <div class="input-group">
                                                    <asp:TextBox ID="txtSapCode" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();" runat="server"
                                                        onkeypress="fncInputNumericValuesOnly('txtQty')"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please insert Employee Code" Display="Dynamic"
                                                        Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtSapCode" SetFocusOnError="true" ValidationGroup="Verify"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtagtcdFTX" runat="server"
                                                        InvalidChars=",#$@%^!*()&''%^~`<>=?./|\{}[]:+;-" FilterMode="InvalidChars" TargetControlID="txtSapCode"
                                                        FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                        <span class="input-group-btn">
                                                    <asp:LinkButton ID="btnVerify" runat="server" Text="Fetch" style=" height: 33px; margin-left: 5px; "
                                                        CssClass="btn btn-success" CausesValidation="true" ValidationGroup="Verify" OnClick="btnVerify_Click" >
                                                            <span class="glyphicon glyphicon-search" style='color:White;'></span> Fetch
                                                        </asp:LinkButton>
                                                    <%--<span style="padding-left: 25px;"></span>--%>
                                                            </span>
                                                       <span class="input-group-btn input-addon_extended">
                                                    <asp:Label ID="lblOR" runat="server" CssClass="control-label" Style="margin-bottom:20px;text-align:center;margin-left: 40px;"  Text="OR"></asp:Label>
                                                            </span>
                                                        </div>
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:Label ID="lblMemberCode" Text="Member Code" CssClass="control-label" runat="server"></asp:Label>
                                                
                                                    <div class="input-group">
                                                    <asp:TextBox ID="txtMemberCode" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();" runat="server"
                                                        onkeypress="fncInputNumericValuesOnly('txtQty')"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please insert Member Code" Display="Dynamic"
                                                        Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtMemberCode" SetFocusOnError="true" ValidationGroup="Fetch"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        InvalidChars=",#$@%^!*()&''%^~`<>=?./|\{}[]:+;-" FilterMode="InvalidChars" TargetControlID="txtMemberCode"
                                                        FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                        <span class="input-group-btn">
                                                    <asp:LinkButton ID="btnFetch" CausesValidation="true" ValidationGroup="Fetch" runat="server" Text="Fetch" style=" height: 33px; margin-left: 5px; "
                                                        CssClass="btn btn-success" OnClick="btnFetch_Click" >
                                                            <span class="glyphicon glyphicon-search" style='color:White;'></span> Fetch
                                                        </asp:LinkButton>
                                                            </span>
                                                        </div>
                                                </div>
                                            </div>
                                                </div>
                                           
                                        <div>
                                            <div class="row rowspacing" id="tr1" runat="server" visible="false">
                                                <div class="col-sm-4">
                                                    <asp:Label ID="lblBizSrc" runat="server" CssClass="control-label" Text="Hierarchy">
                                                    </asp:Label>
                                               
                                                    <asp:DropDownList ID="ddlBizSrc" CssClass="form-control form-select mandatory" AutoPostBack="true"
                                                        runat="server" OnSelectedIndexChanged="ddlBizSrc_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:Label ID="lblSubclass" CssClass="control-label" runat="server" Text="Sub Class"></asp:Label>
                                               
                                                    <asp:DropDownList ID="ddlChnCls" AutoPostBack="true"
                                                        runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                 <div class="col-sm-4">
                                                    <asp:Label ID="lblUntType" runat="server" CssClass="control-label" Text="Unit Type"></asp:Label>
                                               
                                                    <asp:DropDownList ID="ddlUntType" AutoPostBack="true" runat="server" CssClass="form-control form-select mandatory"
                                                        OnSelectedIndexChanged="ddlUntType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row" id="tr2" runat="server" visible="false">
                                               
                                                
                                            </div>
                                            <div class="row rowspacing" id="tr3" runat="server" visible="false">
                                                <div class="col-sm-4">

                                                    <asp:Label ID="lblUnit" runat="server" CssClass="control-label" Text="Branch"></asp:Label>
                                               

                                                    <div class="input-group">
                                                    <asp:DropDownList ID="ddlUnit" CssClass="form-control form-select mandatory" runat="server"></asp:DropDownList>


                                                    <asp:CheckBox ID="chkInclusive" Text="Inclusive" runat="server" style="margin-left: 4px;margin-top: 8px;" />
                                                        </div>

                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:Label ID="lblPrimaryMgr" CssClass="control-label" runat="server" Text="Primary Manager"></asp:Label>
                                               
                                                    <asp:TextBox ID="txtPrmyMgr" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:Label ID="lblAddlMgr1" runat="server" CssClass="control-label" Text="Additional Manager 1"></asp:Label>
                                               
                                                    <asp:TextBox ID="txtAddlMgr1" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row rowspacing" id="tr4" runat="server" visible="false">
                                                <div class="col-sm-4">
                                                    <asp:Label ID="lblAddlmgr2" runat="server" CssClass="control-label" Text="Additional Manager 2"></asp:Label>
                                               
                                                    <asp:TextBox ID="txtAddlMgr2" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-3"></div>
                                            </div>
                                            <div class="row rowspacing">
                                                <div class="col-sm-12" style="text-align: center">
                                                   

                                                        <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click"
                                    Visible="false" TabIndex="17">
                                                     <span class="glyphicon glyphicon-plus" style='color:White;'> </span> Add New
                                                            </asp:LinkButton>
                                                </div>
                                            </div>
                                           </div>
                                        </div>
                                    
                                


                                <tr id="trCustDtls" runat="server" visible="false">
                                    <td colspan="4" class="formcontent">
                                        <table width="100%" class="tableIsys">
                                            <tr style="height: 20px;">
                                                <td align="left" colspan="8" class="test">
                                                    <input runat="server" type="button" class="standardlink" value="-" id="btnCustDtls"
                                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCustDtls', 'ctl00_ContentPlaceHolder1_btnCustDtls');" />
                                                    <asp:Label ID="lblCustDtls" runat="server" Text="Customer Details" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divCustDtls" runat="server">
                                            <table width="100%" class="tableIsys">
                                                <tr>
                                                    <td width="17%" class="formcontent">
                                                        <asp:Label ID="lblCustID" runat="server" Text="Customer ID"></asp:Label><span style="color: Red; margin-left: 0.5px;"> *</span>
                                                    </td>

                                                    <td width="33%" class="formcontent">
                                                        <asp:TextBox ID="txtCustID" CssClass="standardtextbox" BackColor="#FFFFB2" onChange="javascript:this.value=this.value.toUpperCase();" runat="server"
                                                            Width="60%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please insert Cust ID." Display="Dynamic"
                                                            Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtCustID" SetFocusOnError="true" ValidationGroup="CustGroup"></asp:RequiredFieldValidator>

                                                    </td>
                                                    <td width="17%" class="formcontent">
                                                        <asp:Label ID="lblSrvcAgt" Text="Servicing Agent" runat="server"></asp:Label><span style="color: Red; margin-left: 0.5px;"> *</span>
                                                    </td>
                                                    <td width="33%" class="formcontent">
                                                        <asp:TextBox ID="txtSrvcAgt" CssClass="standardtextbox" BackColor="#FFFFB2" onChange="javascript:this.value=this.value.toUpperCase();" runat="server"
                                                            Width="60%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please insert Servicing Agent" Display="Dynamic"
                                                            Font-Size="8pt" CssClass="msgerror" ControlToValidate="txtSrvcAgt" SetFocusOnError="true" ValidationGroup="CustGroup"></asp:RequiredFieldValidator>

                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="formcontent">
                                                        <asp:Label ID="lblMobile" runat="server" Text="Mobile No."></asp:Label>
                                                    </td>
                                                    <td class="formcontent">
                                                        <asp:TextBox ID="txtMobile" CssClass="standardtextbox" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="formcontent"></td>
                                                    <td class="formcontent"></td>

                                                </tr>

                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:Button ID="btnAddCustDtlsToGris" CausesValidation="true" ValidationGroup="CustGroup" runat="server" Text="Add"
                                                            CssClass="standardbutton" OnClick="btnAddCustDtlsToGris_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>

                                </tr>
                                   
                                <div id="trGrid" runat="server" visible="false" style="margin-top: 14px;">
                                    <%--<td colspan="4" class="formcontent">
                                        <div width="100%">--%>
                                            <div class="row">
                                                <div class="col-sm-12" style="overflow-x: scroll">
                                                    <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                                        HorizontalAlign="Left"  PagerStyle-ForeColor="blue" PagerStyle-HorizontalAlign="Center" AllowSorting="True"  CssClass="footable" HeaderStyle-HorizontalAlign="Center" 
                                                         Style="border-bottom-color: black;"  >
                             
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Legal Name" SortExpression="LegalName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLegalName" runat="server" Visible="true" Text='<%# Bind("LegalName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                    <ItemStyle CssClass="clscenter"/>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Emp Code" SortExpression="EmpCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmpCode" runat="server" Visible="true" Text='<%# Bind("EmpCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                    <ItemStyle CssClass="clscenter"/>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Code" SortExpression="MemberCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMemberCode" runat="server" Visible="true" Text='<%# Bind("MemberCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Type" SortExpression="AgentType">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAgentType" runat="server" Visible="true" Text='<%# Bind("AgentType") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                    <ItemStyle CssClass="clscenter"/>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BizSrc" SortExpression="BizSrc">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBizSrc" runat="server" Visible="true" Text='<%# Bind("BizSrc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ChnCls" SortExpression="ChnCls">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnCls" runat="server" Visible="true" Text='<%# Bind("ChnCls") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitCode" runat="server" Visible="true" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitType">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitType" runat="server" Visible="true" Text='<%# Bind("UnitType") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit Name" SortExpression="UnitName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitName" runat="server" Visible="true" Text='<%# Bind("UnitName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PrmyMgrCode" SortExpression="PrmyMgrCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPrmyMgrCode" runat="server" Visible="true" Text='<%# Bind("PrmyMgrCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Addl1MgrCode" SortExpression="Addl1MgrCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAddl1MgrCode" runat="server" Visible="true" Text='<%# Bind("Addl1MgrCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Addl2MgrCode" SortExpression="Addl2MgrCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAddl2MgrCode" runat="server" Visible="true" Text='<%# Bind("Addl2MgrCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton Text="Delete" ID="lbDelete" runat="server" OnClick="lbDelete_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <HeaderStyle CssClass="gridview th"  />
                                                        <PagerStyle CssClass="disablepage" ForeColor="Blue" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                        
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                     <%--   </div>
                                    </td>--%>
                                </div>
                                   
                                <tr id="trGridCustDtls" runat="server" visible="false">
                                    <td colspan="4" class="formcontent">
                                        <table width="100%">
                                            <tr>
                                                <td class="formcontent">
                                                    <asp:GridView ID="gvCustDtls" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                                        HorizontalAlign="Left" Width="100%"
                                                        RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue" BorderStyle="Solid" BorderColor="Gray"
                                                        PagerStyle-HorizontalAlign="Center" AllowSorting="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Customer ID" SortExpression="CustomerID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCustID" runat="server" Text='<%# Bind("CustomerID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Servicing Agent" SortExpression="SrvcAgt">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSrvcAgt" runat="server" Text='<%# Bind("SrvcAgt") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mobile No" SortExpression="MobileNo">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton Text="Delete" ID="lbCustDelete" runat="server"
                                                                        OnClick="lbCustDelete_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <HeaderStyle CssClass="test" ForeColor="DarkBlue" />
                                                        <PagerStyle CssClass="pagelink" ForeColor="Blue" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="sublinkodd"></RowStyle>
                                                        <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            
                            
                    
                    


                        <div style="width: 100%; text-align: left">


                            <div class="row rowspacing">
                                <div class="col-sm-6" style="width: 50%">
                                    <asp:CheckBox ID="chkIsSysAdmin" style="float:left;color:#00cccc" Font-Size="18px"  runat="server" />
                                </div>

                                <div class="col-sm-6" style="width: 50%">
                                    <asp:CheckBox Visible="false" ID="chkTimingRestrict" CssClass="form-control"  runat="server" />
                                    <asp:Button Visible="false" ID="btnEditTime" runat="server" Text="Edit Time Control"
                                        CssClass="btn btn-success" Width="120px" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:CheckBox Visible="false" ID="chkIsForumModerator" CssClass="form-control" runat="server" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:CheckBox Visible="false" ID="chkDownload" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6"></div>
                                <div class="col-sm-6">
                                    <asp:CheckBox Visible="false" ID="chkLogonLocally" CssClass="form-control" runat="server" Text="User cannot logon locally" />
                                </div>
                            </div>
                            <div class="row rowspacing">
                                <div class="col-sm-12">
                                    <asp:Button ID="btnResetpw" Visible="true" runat="server" Text="Reset Password" CssClass="btn btn-success" OnClick="btnResetpw_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
               </asp:View>
                                 
                            <asp:View ID="View4" runat="server">
                <div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div>
                                <div class="TabContent">

                                    <div style="margin-left:110px;margin-top:-11px">
                                        <div class="row">
                                            <div class="col-sm-6" >
                                                <asp:Panel ID="Panel6" runat="server" Height="350px" ScrollBars="Auto"  HorizontalAlign="Left"
                                                    BorderStyle="Solid" BorderColor="black" BorderWidth="1pt" BackColor="#f2f5ff">
                                                    <span style="font-family: Tahoma"></span>
                                                    <asp:GridView ID="dgSRARights" runat="server"
                                                        AutoGenerateColumns="False"
                                                        Width="590px" DataKeyNames="SrvcTypCode"
                                                        AllowPaging="False" AllowSorting="True" HorizontalAlign="left"
                                                        RowStyle-CssClass="formtable" GridLines="Vertical"
                                                        OnRowDataBound="dgSRARights_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SrvcTypCode" Visible="true" SortExpression="SrvcTypCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SrvcTypCode" runat="server" Text='<%# Bind("SrvcTypCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Group Code" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SrvcGrpCode" runat="server" Text='<%# Bind("GroupCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Group Name" Visible="true" SortExpression="GroupName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="GroupName" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Service Name" Visible="true" SortExpression="SrvName" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SrvName" runat="server" Text='<%# Bind("SrvName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Access Right" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkAccessRight" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Post to LA" Visible="true">
                                                                <ItemTemplate>
                                                                    <input type="hidden" runat="server" id="txtPostTOLA" name="txtPostTOLA" value='<%# Bind("PostTOLA") %>' />
                                                                    <asp:CheckBox ID="chkPostTOLA" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ACC" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="ACC" runat="server" Text='<%# Bind("ACC") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="AcCPTL" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="AcCPTL" runat="server" Text='<%# Bind("AcCPTL") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="formlink" />
                                                        <AlternatingRowStyle CssClass="sublinkeven" />
                                                        <RowStyle CssClass="sublinkodd" />
                                                        <PagerStyle CssClass="pagelink" />
                                                        <EmptyDataTemplate>
                                                            <asp:Label ID="lblNoRecord" runat="server" Text="No Record Found"></asp:Label>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>

                                                    <div style="height: 320px; width: 560px; display: none;" id="divUserSanc">


                                                        <iframe height="320px" scrolling="auto"  runat="server" id="ifrmUserSanc"></iframe>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div class="col-sm-6" style="height: 320px;" valign="top">
                                                <asp:Label ID="lblUserGroupGrp" runat="server" Visible="False" />
                                                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Auto" Width="360px" HorizontalAlign="Left"
                                                    BorderStyle="Solid" BorderColor="black" BorderWidth="1pt" BackColor="#f2f5ff">
                                                    <strong><span style="font-family: Tahoma">
                                                        <asp:Label ID="lblSelectedModule" runat="server" Text="Selected Module"></asp:Label></span></strong>
                                                    <asp:TreeView ID="TrVUser" runat="server" ShowCheckBoxes="All" ShowLines="True"
                                                        Width="324px" CssClass="T1" Style="text-align: left">
                                                        <LeafNodeStyle CssClass="T1" />
                                                        <ParentNodeStyle CssClass="T1" />
                                                        <RootNodeStyle CssClass="T1" />
                                                        <NodeStyle CssClass="T1" />
                                                    </asp:TreeView>
                                                    <br />
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:View>
                                    

                            <asp:View ID="View3" runat="server">
                <table width="100%" align="center">
                    <tr>
                        <td style="height: 389px">
                            <div class="ImgTab">

                                <div class="TabContent"></div>
                            </div>
                        </td>
                    </tr>
                </table>

            </asp:View>  

             </div>
            </asp:MultiView>
              </div>
                </div>
                </div>

                    </div>
                  
        </ContentTemplate>

    </asp:UpdatePanel>

    <br />


    <div runat="server" id="PnlBlocker" style="z-index: 100; filter: alpha(opacity=40); left: 0px; width: 100%; display: none; position: absolute; top: 0px; height: 60%; background-color: #cccccc; moz-opacity: .40; opacity: .40; font-size: 9pt;">
        <table id="Table1" runat="server">
            <tr>
                <td style="width: 100%; height: 480px" />
            </tr>
        </table>
    </div>

    <asp:Panel ID="Panel2" runat="server" Height="318px" ScrollBars="Auto" Width="397px" BackColor="#f2f5ff" BorderColor="black" BorderStyle="solid" BorderWidth="1px"
        HorizontalAlign="Center" Style="left: 179pt; position: absolute; top: 33pt; z-index: 101;" Visible="false">
        <strong><span style="font-family: Tahoma" id="title" runat="server">User's
            Module Accessibility Summary</span></strong>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel Height="300px" runat="server" ScrollBars="Auto">
                        <asp:TreeView ID="TrVModule" runat="server" ShowCheckBoxes="All" ShowLines="True" Enabled="false" Height="300px"
                            Width="334px" CssClass="T1" Style="text-align: left">
                            <LeafNodeStyle Font-Names="Tahoma" Font-Size="X-Small" CssClass="T1" />
                        </asp:TreeView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblUGID" runat="server" Visible="False" />
                    <asp:Label ID="lblUGName" runat="server" Visible="False" />
                    <asp:Label ID="lblUGCC" runat="server" Visible="False" />
                    <asp:CheckBox ID="CheckBox4" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="Small" Text="Apply to all existing user" Width="261px" Visible="false" />
                    <asp:Button ID="btnUpdate" runat="server" CssClass="standardbutton" Text="Update" OnClick="btnUpdate_Click"
                        Visible="false" />

                </td>
            </tr>
        </table>
        <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="standardbutton" OnClick="btnClose_Click" />
    </asp:Panel>

    <div style="text-align: center; position: relative;">

        <asp:LinkButton ID="linkSave" runat="server" CausesValidation="true" ValidationGroup="NewsUserGroup" CssClass="btn btn-success" OnClick="linkSave_Click">
             <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span>  Save
        </asp:LinkButton>

         

        <asp:LinkButton ID="linkClear" runat="server" CausesValidation="true" ValidationGroup="NewsUserGroup" CssClass="btn btn-success"
             OnClientClick="return confirm('Are you sure you want to clear this module?');" OnClick="linkClear_Click" Visible="false" Text="Clear"  >
               <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
        </asp:LinkButton>

        <asp:LinkButton ID="linkCancel" runat="server" CssClass="btn btn-clear" OnClick="linkCancel_Click">
           <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:red;"> </span> Cancel
        </asp:LinkButton>
    </div>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDirectConnectionString %>" />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDirectConnectionString %>"
        SelectCommand="SELECT lookupCode, paramValue, paramDesc01, sortOrder, paramNote, paramDescShort FROM iSysLookupParam WHERE (lookupCode = 'userstat')"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDirectConnectionString %>"
        SelectCommand="SELECT lookupCode, paramValue, paramDesc01, sortOrder, paramNote, paramDescShort FROM iSysLookupParam WHERE (lookupCode = 'usertype') ORDER BY sortOrder"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDirectConnectionString %>"
        SelectCommand="SELECT distinct opUnitCode as paramCode, opUnitName FROM iOpUnit"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDirectConnectionString %>"
        SelectCommand="SELECT lookupCode, paramValue, paramDesc01, sortOrder, paramNote, paramDescShort FROM iSysLookupParam WHERE (lookupCode = 'userRole') ORDER BY sortOrder"></asp:SqlDataSource>



</asp:Content>

