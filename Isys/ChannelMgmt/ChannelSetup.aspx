<%--Modifier:		    <Ajay Yadav> 
    Create date:      <17th Sep 2021>
    Description:	    <Modified codes for (Code Optimization)>
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChannelSetup.aspx.cs" Inherits="INSCL.ChannelSetup"
    MasterPageFile="~/iFrame.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <%--<link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
         <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
        <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Common/Scripts/dynamicdiv.js"></script>


    <script type="text/javascript">
        

        function funcShowPopupLOB() {
            debugger;
            $find("mdlViewBIDLOB").show();
            var prdcode = document.getElementById('<%= hdnprdcode.ClientID%>').value;
            var ProdcodeEdit = document.getElementById('<%= hdnProdcodeEdit.ClientID%>').value;
            var Chntype = document.getElementById('<%= hdnChntype.ClientID%>').value;
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblChannel') != null) {
                var Bizsrc = document.getElementById('ctl00_ContentPlaceHolder1_lblChannel').innerText;
            }
            else { var Bizsrc = ""; }
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=" + 'MdlPopExtndrLOB' + "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&Bizsrc=" + Bizsrc + "&ChnType=" + Chntype;
            alert("ajay");
        }

         //added by babita 
        function Addsubdiv(Name,flag) {
            debugger
            var arr = Name.split(",");
			if (document.getElementById("ctl00_ContentPlaceHolder1_DIVsubchannel").style.display == 'none') {
				document.getElementById("ctl00_ContentPlaceHolder1_DIVsubchannel").style.display = 'block';
			}
			if (flag == "S") {
				//divisvisible('');
                var html;
                for (var i = 0; i < arr.length; i++) {
                    //html = "<div class='divspecial'>" + Name;
                    html = "<div class='divspecial'>" + arr[i];
                    //html += "<asp:LinkButton ID='lnk" + ID +  "OnClick='deletediv("+ ID +");'>";
                    //html += "<a onclick='deletediv(" + ID + "," + KPI_CODE + ")'; id='lnk" + ID + "'>";
                    //html += "<span class='glyphicon glyphicon-remove' style='color:black'></span>";
                    //html += "</asp:LinkButton>";
                    //html += "</a>";
                    html += "</div>";
                    //document.getElementById("ctl00_ContentPlaceHolder1_Div38").innerHTML += "<div Id='div"+ID+"' class='divspecial'>" + Name + "</div>";

                    document.getElementById("ctl00_ContentPlaceHolder1_DIVsubchannel").innerHTML += html;
                }
			}
			else {
				var myArray = JSON.parse(Name);
				for (var i = 0; i < myArray.length; i++) {
					var obj = myArray[i];
					//console.log("Name: " + obj.name + ", Age: " + obj.age);
					var html;
					html = "<div Id='div" + obj.OBJ_ID + "' class='divspecial'>" + obj.TBL_NAME;
					//html += "<asp:LinkButton ID='lnk" + ID +  "OnClick='deletediv("+ ID +");'>";
					if (obj.Flag == "0") {
						//html += "<a onclick='deletediv(" + obj.OBJ_ID + "," + KPI_CODE + ")'; id='lnk" + ID + "'>";
						html += "<span class='glyphicon glyphicon-remove' style='color:black'></span>";
						//html += "</asp:LinkButton>";
						html += "</a>";
					}
					html += "</div>";
					//document.getElementById("ctl00_ContentPlaceHolder1_Div38").innerHTML += "<div Id='div"+ID+"' class='divspecial'>" + Name + "</div>";

					document.getElementById("ctl00_ContentPlaceHolder1_DIVsubchannel").innerHTML += html;
				}
				//document.getElementById("ctl00_ContentPlaceHolder1_Div38").innerHTML += myArray;
			}
		}
        //ended by babita
    </script>

  <%--  <script type="text/javascript">
        function funcShowPopupLOB() {
            debugger;
            $find("mdlViewBIDLOB").show();
            var prdcode = "";
            var ProdcodeEdit = document.getElementById('<%= hdnProdcodeEdit.ClientID%>').value;
            var Chntype = document.getElementById('<%= hdnChntype.ClientID%>').value;
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblChannel') != null) {
                var Bizsrc = document.getElementById('ctl00_ContentPlaceHolder1_lblChannel').innerText;
            }
            else { var Bizsrc = ""; }
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=" + 'MdlPopExtndrLOB' + "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&Bizsrc=" + Bizsrc + "&ChnType=" + Chntype;
            alert("ajay");
        }
    </script>--%>

    <script lang="javascript" type="text/javascript">

        //Popup Of History Page Function. 
        function funPopUp() {
            debugger;
            var start = document.getElementById("ctl00_ContentPlaceHolder1_lblChannel");
            var value = start.textContent;
            var Header = "Version History Of Channel";
            var Flag = "CHANNEL";
            $find("mdlViewBIDLOB").show()
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopupCompanyHistory.aspx?&Code=" + value + "&mdlpopup=mdlViewBIDLOB" + "&Header=" + Header + "&Flag=" + Flag;
        }

        function popup() {
            //$("#myModal").modal();
            debugger;
            var id = document.getElementById("myModal");
            id.style.display = "block";
        }
        function Closepopup() {
            debugger;
            var id = document.getElementById("myModal");
            id.style.display = "none";
        }
        
        //Ajax Call For Date Control For Certain Condition
        $(function () {
            debugger;
           // $("#<%= txtEffDate.ClientID  %>").datepicker({ minDate: 0, maxDate: '31/03/2024', dateFormat: 'dd/mm/yy' });  //changed by sanoj 23052023 minDate: 0
            $("#<%= txtEffDate.ClientID  %>").datepicker({ maxDate: '31/03/2024', dateFormat: 'dd/mm/yy' }); 
            $("#<%= txtCseDt.ClientID  %>").datepicker({ maxDate: '+365d', minDate: '-0d', dateFormat: 'dd/mm/yy' });
            $("#<%= txtCseDt1.ClientID  %>").datepicker({ maxDate: '+365d', minDate: '-0d', dateFormat: 'dd/mm/yy' });
            //$("#<%= txtIncorporation.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtIncorporation.ClientID  %>").datepicker({ maxDate: '-0d', dateFormat: 'dd/mm/yy' });

        });

        //Collapse Down-Up Function.
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
                ////ShowError(err.description);
            }
        }


        function cancel(flag, chnTyp) {
            if (flag == 'V') {
                if (window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>') != null) {
                    window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
                }
            }
            else if (chnTyp == 'C') {
                window.location.href = "ChannelMas.aspx";
            }
            else if (chnTyp == 'O') {
                window.location.href = "CompanyMaster.aspx";
            }
        }

        //Compulsory Control Validation Function
        function validate() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "txtChannel") != null) {
                if (document.getElementById(strContent + "txtChannel").value == "") {
                    alert("Please Enter Channel");
                    document.getElementById(strContent + "txtChannel").focus();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtDesc1").value == "") {
                alert("Please Enter Channel Description 1");
                document.getElementById(strContent + "txtDesc1").focus();
                return false;
            }

            if (document.getElementById(strContent + "txtEffDate") != null) {
                if (document.getElementById(strContent + "txtEffDate").value == "") {
                    alert("Please Enter Effective Date");
                    document.getElementById(strContent + "txtEffDate").focus();
                    return false;
                }
            }
        }
    </script>
    <%--added by babita--%>
     <style>
        
       
        .divspecial {
  background-color: #ddd;
  border: none;
  color: black;
  padding: 10px 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  margin: 4px 2px;
  /*cursor: pointer;*/
  border-radius: 16px;
}

        
    </style>
    
    <%--Ended by Babita--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <center>

           <%--Modification Setup Div --%>
                    <div class="panel" id="divModification" runat="server" style="margin-left: 2%; margin-right: 2%;">
                  <div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
         <asp:Label ID="Label21" runat="server" Text="CORRECTION OR CHANGES IN CHANNEL SETUP"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivmodify" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>
               <div id="divmodifybody" runat="server" class="panel-body" style="display:block">
               <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left;margin-top: 10px;">
                        <asp:Label ID="lblModMode" runat="server" Text="Mod Mode" CssClass="control-label" /> 
                        <span style="color: #ff0000"> *</span>
                        </div>
                         <div class="col-md-3" style="text-align:left"  >
                        <div class="btn-group"  role="group" style="margin-left: -162px;">
                        <asp:RadioButtonList  ID="rbCorrection" runat="server"  CellPadding="2" CellSpacing="2"  RepeatDirection="Horizontal"  AutoPostBack="true" 
                     OnSelectedIndexChanged="rbCorrection_OnSelectedIndexChanged">
                        <asp:ListItem Text="&nbspCorrection&nbsp" selected="True" value="CR"  class="btn btn-default"  />
                        <asp:ListItem Text="&nbspChanges&nbsp"  value="CH"  class="btn btn-default" style="margin-left: 0px;"  />
                     </asp:RadioButtonList>
                    </div>
                       </div>
                        <div class="col-md-3">
                     </div>
                      <div class="col-md-3">
                     </div>
                  </div>
                </div>
            </div>
            <div class="panel" id="divcmphdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%;">
             

                <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','btndivcmphdr');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblslsHead" runat="server" Text="HIERARCHY SETUP"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivcmphdr" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         

           </div>

                <div id="divcmphdr" runat="server" class="panel-body" style="display:block"> 
                   <div class="row" style="margin-bottom:5px;">
               <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblSaleschannel" runat="server" CssClass="control-label"/> 
                                        <span style="color: #ff0000"> *</span>
                     </div>
                  <div class="col-md-3" style="text-align:left">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                            <asp:Label ID="lblChannel" runat="server" Visible="False" CssClass="control-label"></asp:Label>
                            <asp:TextBox ID="txtChannel" runat="server" Visible="False" CssClass="form-control" TabIndex="1" OnTextChanged="txtChannel_TextChanged" AutoPostBack="true"
                                    MaxLength="2" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="txtChannelFTX" runat="server" TargetControlID="txtChannel"
                                FilterType="Custom, LowercaseLetters, UppercaseLetters">
                            </ajaxToolkit:FilteredTextBoxExtender>
                                  </contenttemplate> 
                           </asp:UpdatePanel> 
                    </div>
                  <div class="col-md-3">
                    </div>
                    <div class="col-md-3">
                    </div>
                  </div>
                   <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left">
                        <asp:Label ID="lblDesc1" runat="server" CssClass="control-label"></asp:Label><span
                            style="color: #ff0000"> *</span>
                       </div>
                       <div class="col-md-3">
                            <asp:TextBox ID="txtDesc1" runat="server" CssClass="form-control"  TabIndex="2"
                                MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                ValidChars=" " FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                TargetControlID="txtDesc1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                       </div>
                       <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblDesc2" runat="server" Height="22px" CssClass="control-label"></asp:Label>
                       </div>
                       <div class="col-md-3">
                            <asp:TextBox ID="txtDesc2" runat="server" CssClass="form-control" MaxLength="50" TabIndex="3"
                                onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                ValidChars=" " FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                TargetControlID="txtDesc2">
                            </ajaxToolkit:FilteredTextBoxExtender>
                      </div>
                     </div>
                   <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblDesc3" runat="server"  CssClass="control-label"></asp:Label>
                        </div>
                       <div class="col-md-3">
                            <asp:TextBox ID="txtDesc3" runat="server" CssClass="form-control" MaxLength="50" TabIndex="3"
                            onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                            ValidChars=" " FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                            TargetControlID="txtDesc3">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                       <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblSortorder" CssClass="control-label" runat="server" />
                            <%--<span style="color: #ff0000"> *</span>--%>
                       </div>
                       <div class="col-md-3">
                           <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                              <ContentTemplate>
                            <%--<asp:TextBox ID="txtSortorder" runat="server" CssClass="form-control" MaxLength="2" TabIndex="4" OnTextChanged="txtSortorder_TextChanged" AutoPostBack="true"></asp:TextBox>--%>

                                  <asp:TextBox ID="txtSortorder" runat="server" CssClass="form-control" MaxLength="2" TabIndex="4" ></asp:TextBox>

                            <ajaxToolkit:FilteredTextBoxExtender ID="txtSortorderFTX" runat="server" ValidChars="01234567890"
                                TargetControlID="txtSortorder" FilterType="Custom,Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                             </contenttemplate> 
       </asp:UpdatePanel> 
                      </div>
                      </div>
                   <div class="row" style="margin-bottom:5px;">
                        <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblParanetChn" Text="Parent Channel" CssClass="control-label" runat="server" />
                            </div>
                        <div class="col-md-3">
                                <asp:DropDownList ID="ddlParentChnl" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                        </div>
                    </div>
            </div>
        
        </div>

           <%--Hierarchy Setup Div --%>
            <div class="panel" id="div5" runat="server" style="display:none;margin-left: 2%; margin-right: 2%;">
            <div id="Div9" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div6','Span1');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label5" runat="server" Text="Hierarchy Setup"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                         <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>   
            <div id="div6" runat="server" class="panel-body" style="display:block">
                <div class="row" style="margin-bottom: 10px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label2" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-9" style="text-align: center">
                          <asp:Label ID="Label1" runat="server" CssClass="control-label" ForeColor="Blue" ></asp:Label>
                    </div>
                   </div> 
                
                <div class="row" style="margin-top: 10px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label4" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                      <div class="col-sm-9" style="text-align:center">
                        <asp:Label ID="lblDesc" runat="server" CssClass="control-label" ForeColor="Blue" ></asp:Label>
                    </div>
                    </div>
                    <div class="row" style="margin-top: 10px;">
                    <div class="col-sm-3" style="text-align: left;">
                        <asp:Label ID="Label6" runat="server" Height="22px" CssClass="control-label"></asp:Label>
                     </div>
                     <div class="col-sm-9" style="text-align: center">
                     <asp:Label ID="lblDesc22" runat="server" CssClass="control-label" ForeColor="Blue" ></asp:Label>
                    </div>
                   </div>
                <div class="row" style="margin-bottom: 3px;">
                    <div class="col-sm-3" style="text-align: left; margin-top:5px;">
                        <asp:Label ID="Label8" runat="server" Height="22px" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-sm-9" style="text-align: center; margin-top:5px;">
                        <asp:Label ID="lblDesc33" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                    </div>
                 </div>
                 <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left;">
                        <asp:Label ID="Label10" CssClass="control-label" runat="server" />
                    </div>
                    <div class="col-sm-9" style="text-align: center;">
                        <asp:Label ID="lblSortorder1" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                    </div>
                   </div>
                </div>
            </div>
   
           <%--Additional Details Setup Div --%>
           <div class="panel" id="div13" runat="server" style="display:none;margin-left: 2%; margin-right: 2%;">
              <div id="Div14" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div15','Span3');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label7" runat="server" Text="ADDITIONAL DETAILS" CssClass="control-label"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                         <span id="Span3" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 

        </div>

          <div id="div15" runat="server" class="panel-body" style="display:block"> 
           <div class="row">
               <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="Label9" CssClass="control-label" Text="Company Name" runat="server" /> 
                 </div>
                 <div class="col-sm-9" style="text-align:center">
                                        <asp:Label ID="CompanyNamePop" runat="server" CssClass="control-label" 
                                            ForeColor="Blue" />                                                                                 
                    </div>
           </div>
                     <div class="row">
                                      <div class="col-sm-3" style="text-align:left;margin-top:10px;">
                                        <asp:Label ID="Label14" CssClass="control-label" Text="Insurer Type" runat="server" />
                                        </div>
                          <div class="col-sm-9" style="text-align:center;margin-top:10px;"> 
                                        <asp:Label ID="DropDownListPop" runat="server" CssClass="control-label" 
                                            ForeColor="Blue" />                                      
                     </div>

            </div>                            
             <div class="row" style="margin-top:10px;">
                 <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="Label16" CssClass="control-label" Text="Year of incorporation" runat="server" />
                    </div>
                    <div class="col-sm-9" style="text-align:center">
                                       <asp:Label ID="YrOfIncPop" runat="server" CssClass="control-label" ForeColor="Blue"/>                                     
                    </div>
              </div>
              <div class="row" style="margin-top:10px;">
                     <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="Label18" CssClass="control-label" Text="IRDAI License Number" runat="server" />
                     </div>
                     <div class="col-sm-9" style="text-align:center;">
                                        <asp:Label ID="IrdaLcnPop" runat="server" CssClass="control-label" ForeColor="Blue"/>                                  
                    </div>
             </div>
                <div class="row" style="margin-bottom:5px;margin-top:10px;">
                  <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="Label20" CssClass="control-label" Text="Registered Office Address" runat="server" />
                  </div>
                  <div class="col-sm-9" style="text-align:center">
                                        <asp:Label ID="RegAddrPop" runat="server" CssClass="control-label" ForeColor="Blue"/>                                      
                    </div>
                </div>
          </div>
          </div>

         <%--  <br/>--%>
             <%--Additional Details Setup Div --%> <%--I have to check it which one is used--%>
           <div class="panel" id="div11" runat="server" style="margin-left: 2%; margin-right: 2%;">
              <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAddDtls','btnAddsrch');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblAddDtls" runat="server" Text="ADDITIONAL DETAILS"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                         <span id="btnAddsrch" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 

        </div>

          <div id="divAddDtls" runat="server" class="panel-body" style="display:block"> 
           <div class="row" style="margin-bottom:5px;">
               <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblcomp" CssClass="control-label" Text="Company Name" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtComp" runat="server" CssClass="form-control"  TabIndex="5"/>
                    </div>
               <div  class="col-sm-3"  style="text-align:left"  >
                                                    <asp:Label ID="lblinsurance"  Text ="Insurer Type" runat="server" CssClass="control-label"></asp:Label> 
                                                </div>
               <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdPanelCategory" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="ddlinsurance"   runat="server" CssClass="form-control" 
                                                              
                                                                TabIndex="6"></asp:DropDownList>
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                         </div>

           </div>
             <div class="row" style="margin-bottom:5px;">
                 <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="Label11" CssClass="control-label" Text="Year of incorporation" runat="server" />
                    </div>
               <div class="col-md-3">

                                        <asp:TextBox ID="txtIncorporation" runat="server" CssClass="form-control" TabIndex="7" />
                    </div>

                   <div class="col-md-3" style="text-align:left">
                          <asp:Label ID="lblOffc" CssClass="control-label" Text="Registered Office Address" runat="server" />
                    </div>
                  <div class="col-md-3">
                          <asp:TextBox ID="txtRegAddr" runat="server" Height="100px" CssClass="form-control"  TextMode="MultiLine" TabIndex="9" />
                    </div>

                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lbllcn" CssClass="control-label" Text="IRDAI License Number" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtIrdaLcn" runat="server" CssClass="form-control" TabIndex="8" />
                    </div>
             </div>


              <%--need to remove--%>
              <div class="row" id="hideonChnl" runat="server"  style="display:none;"> 
                    <div class="col-md-3" style="text-align:left">
                          <asp:Label ID="Label22" text="Business year: " runat="server" CssClass="control-label" /> 
                    </div>

                    <div class="col-md-3">
                    <asp:RadioButtonList ID="rdoBusiYr" runat="server" CellPadding="2" CellSpacing="2"
                                    RepeatDirection="Horizontal" >
                                    <asp:ListItem Text="&nbspApril to March&nbsp&nbsp&nbsp&nbsp" Value="0">  </asp:ListItem>
                                    <asp:ListItem Text="&nbspJanuary to December&nbsp&nbsp" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                   </div>

                    <div class="col-md-3">  
                          <asp:Label ID="lblnew" Text="Freeze Business date:" runat="server" CssClass="control-label" style="margin-left: -152px;"/>
                           </div>

                    <div class="col-md-1">  
                        <asp:CheckBox ID="CheckBox1"  style="margin-left: -407px;margin-top: 2px;"     runat="server" Text="" /> 
                        </div>

                    <div class="col-md-2">   
                     <asp:TextBox ID="txtCseDt1"  style="width: 278px;margin-left: -90px;background-color:white !important" runat="server"  CssClass="form-control" TabIndex="13"  />  
                  </div>
                  </div>

                <div class="row" style="margin-bottom:5px;">
                <%--  <div class="col-md-3" style="text-align:left">
                          <asp:Label ID="lblOffc" CssClass="control-label" Text="Registered Office Address" runat="server" />
                    </div>
                  <div class="col-md-3">
                          <asp:TextBox ID="txtRegAddr" runat="server" Height="100px" CssClass="form-control"  TextMode="MultiLine" TabIndex="9" />
                                       
                    </div>--%>
                </div>
          </div>
           </div>
           <br />
        <%--added by babita--%>
          <div class="panel" id="divsubchanel" runat="server" style="margin-left: 2%; margin-right: 2%;">
              <div id="divchde" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DIVsubchannel','snapsubchannel');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label23" runat="server" Text="SUB CHANNEL DETAILS" CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="snapsubchannel" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 
        </div>

             <div id="DIVsubchannel" runat="server" class="panel-body" style="display:block"> 
                 <div class="row" style="margin-bottom:5px;">
               <%--<div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="Label26" CssClass="control-label" Text="Channel Details" runat="server" />
                    </div>
                      <div class="col-sm-3">
                                        <asp:DropDownList id="ddlchanneldet" runat="server" CssClass="form-control"  TabIndex="6"></asp:DropDownList>
                                         </div>--%>
           </div>

                 <div id="divaddsubchannel" runat="server" style="display:none" class="row">
				 <br />
                 </div>
                
             </div>
                 <%--ADDED BY AJAY NEW DIV 29 MAY 2023 START--%>
                 <div id="container" runat="server" style="margin-left: 20px;margin-top: -13px;border-top: none;" class="panel-body"></div>
              
                 <%--ADDED BY AJAY NEW DIV 29 MAY 2023 END--%>
                   

            </div>
        <%--ended by babita--%>
           <%--Product Details Setup Div --%>
           <div class="panel" id="div16" runat="server" style="margin-left: 2%; margin-right: 2%; display:none">
          <div  id="divprodtls" runat="server" >
              <div id="Div17" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divProducrGridDtls','spnsrch');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblprodname" runat="server" Text="PRODUCT DETAILS"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="spnsrch" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                          <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
                    </div>
                </div> 
            </div>
     
              <div id="divChannel" runat="server" style="width:96.6%;" class="container panel-body" >
             <div class="row">
                <div class="col-sm-8" style="text-align: center">                       
                    <asp:LinkButton ID="lnkbtnaddprod" runat="server"  CssClass="btn btn-sample" 
                    CausesValidation="false" TabIndex="14" OnClick="lnkbtnaddprod_Click">
                    <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Add Product
                    </asp:LinkButton>
                     </div>
                    <div class="col-sm-2">
                         <asp:Label ID="lblstatus" CssClass="control-label" Text="Product Status" runat="server" />
                </div> 
                 <div class="col-sm-2">
                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control" Enabled="false">
                        <asp:ListItem Value="All" Text="All"  Selected="True"> </asp:ListItem>
                         <asp:ListItem Value="A" Text="Active"> </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
             <br />
             <div id="divProducrGridDtls" runat="server"  visible="false"> 
                <asp:GridView ID="GridProdDtls" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#F6F6F6" CssClass="footable"
                    PageSize="10" AllowSorting="True" AllowPaging="True" DataKeyNames="ProductCode,ProductName" OnRowDataBound="GridProdDtls_RowDataBound"> <%--OnRowDataBound="GridProdDtls_RowDataBound"--%>
                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                    <PagerStyle CssClass="disablepage" />
                    <HeaderStyle CssClass="gridview th" HorizontalAlign="Left" />
                    <Columns>                       
                        <asp:TemplateField HeaderText="Product Code" HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblProdCode" runat="server" CssClass="standardlabel" Text='<%# Eval("ProductCode").ToString() %>'></asp:Label>
                                <asp:HiddenField ID="hndProductCode" runat="server" Value='<%# Eval("ProductCode").ToString() %>'
                                    Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblProdName" CssClass="standardlabel" runat="server" Text='<%# Eval("ProductName").ToString() %>'></asp:Label>
                                <asp:HiddenField ID="hndProductName" runat="server" Value='<%# Eval("ProductName").ToString() %>'
                                    Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Effective Date" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblEffFromDate" CssClass="standardlabel" runat="server" Text='<%# Eval("EffFromDate").ToString() %>'></asp:Label>
                                <asp:HiddenField ID="hdnEffFromDate" runat="server" Value='<%# Eval("EffFromDate").ToString() %>'
                                    Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="LOB Code" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblLobCode" CssClass="standardlabel" runat="server" Text='<%# Eval("LobCode").ToString() %>'></asp:Label>
                                <asp:HiddenField ID="hdnLobCode" runat="server" Value='<%# Eval("LobCode").ToString() %>'
                                    Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" CssClass="standardlabel" runat="server" Text='<%# Eval("Status").ToString() %>'></asp:Label>
                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Status").ToString() %>'
                                    Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cease Date" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblCeaseDtim" CssClass="standardlabel" runat="server" Text='<%# Eval("CeaseDtim").ToString() %>'></asp:Label>
                                <asp:HiddenField ID="hdnCeaseDtim" runat="server" Value='<%# Eval("CeaseDtim").ToString() %>'
                                    Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="lnkdelete" Text="Delete" CommandName="Delete" CssClass="btn btn-sample" OnClientClick ="return funcShowPopupCease(this);"   /><%--CausesValidation="false"OnClick="lnkdelete_Click"--%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
                <br />
                <center>
                    <table id="tblpagination" runat="server" visible="false"> 
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
                        </td>
                        </tr>
                    </table>
                </center>
                <br />
                  
                   <center> 
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" Width="310px"></asp:Label><%--Style='margin-left: 192px;' --%>
                    </center>
            </div>
           </div>
          </div>
         </div>
        <%--   <br />--%>

           <%--Other Details Setup Div --%>
           <div class="panel" id="div1" runat="server" style="margin-left: 2%; margin-right: 2%;">
                <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divkpisrch','btndivkpisrch');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblhdr" runat="server" TEXT="OTHER DETAILS" CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivkpisrch" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 

        </div>
          <div id="divkpisrch" runat="server" class="panel-body" style="display:block"> 
             <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblPer" CssClass="control-label" runat="server" />
                    </div>
                     <div class="col-md-3">
                            <asp:DropDownList ID="ddlFinancialYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                                    <asp:TextBox ID="txtFinYr" Visible="false" runat="server" CssClass="form-control" TabIndex="10" style="margin-left:2px" MaxLength="10"/>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" FilterType="Custom, Numbers"
                                        runat="server" ValidChars="-" TargetControlID="txtFinYr">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                      </div>
                    <div class="col-md-3" style="text-align:left">
                                  <asp:Label ID="lblVer" CssClass="control-label" runat="server" />
                    </div>
                  <div class="col-md-3">
                        <asp:TextBox ID="txtVer" runat="server" CssClass="form-control" TabIndex="11" style="margin-left:-6px"/>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" FilterType="Custom, Numbers" runat="server" ValidChars="." TargetControlID="txtVer">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
              </div>
                <div class="row" style="margin-bottom:5px;">
                 <div class="col-md-3" style="text-align:left">
                    <asp:Label ID="lblEffDate" runat="server" CssClass="control-label" />
                    <span style="color: #ff0000"> *</span>
                </div>
                   <div class="col-md-3">
                        <asp:TextBox ID="txtEffDate" runat="server" CssClass="form-control" TabIndex="12" style="margin-left:2px;background-color:white !important"/>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" FilterType="Custom, Numbers" runat="server" ValidChars="/" TargetControlID="txtEffDate">
                        </ajaxToolkit:FilteredTextBoxExtender>
                   </div>
                   <div class="col-md-3" style="text-align:left">
                          <asp:Label ID="lblCseDt" runat="server" CssClass="control-label" />
                 </div>
                   <div class="col-md-3">
                    <asp:TextBox ID="txtCseDt" runat="server" CssClass="form-control" TabIndex="13" style="margin-left:-6px;background-color:white !important"/>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" FilterType="Custom, Numbers" runat="server" ValidChars="/" TargetControlID="txtCseDt">
                    </ajaxToolkit:FilteredTextBoxExtender>
                  </div>
                 </div>

               <div class="row" style="margin-bottom:5px;">
                  <div class="col-md-3" style="text-align:left">
                    <asp:Label ID="lblChnStatus" Text="Status " runat="server" CssClass="control-label" /> 
                       <span style="color: #ff0000"> *</span>
                  </div>
                  <div class="col-sm-3">
                    <asp:DropDownList Enabled="false" id="ddllStatus" style="margin-right: -3px;" CssClass="form-control"  runat="server">
                    <asp:ListItem   Value="Draft">Draft</asp:ListItem>
                     <asp:ListItem Selected="True" Value="Final">Final</asp:ListItem>
                    </asp:DropDownList>
                   </div>
               </div>
            </div>
        </div>
       <%--    <br />--%>
           <%--Other Details Setup Div --%><%--I have to check it which one is used--%>
           <div id="div7" runat="server" class="panel" style="display:none;margin-left: 2%; margin-right: 2%;">
            
            <div id="Div10" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div8','Span2');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label12" runat="server"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                         <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 
                  </div>
            <div id="div8" runat="server" class="panel-body" style="display:block">
                 <div class="row" style="margin-bottom:10px;">
                    <div class="col-sm-3" style="text-align:left;">
                        <asp:Label ID="Label13" CssClass="control-label" runat="server" />
                    </div>
                    <div class="col-sm-9" style="text-align:center">
                        <asp:Label ID="lblFinYr" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                    </div>
                 </div>
                <div class="row" style="margin-bottom:10px;">
                    <div class="col-sm-3" style="text-align:left;">
                        <asp:Label ID="Label15" CssClass="control-label" runat="server" />
                    </div>                                  
                    <div class="col-sm-9" style="text-align:center">
                        <asp:Label ID="lblVer1" runat="server"  CssClass="control-label" ForeColor="Blue"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-bottom:10px;">
                    <div class="col-sm-3" style="text-align:left;">
                       <asp:Label ID="Label17" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-9" style="text-align:center;">
                        <asp:Label ID="lblEffDate1" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-bottom:10px;">
                     <div class="col-sm-3" style="text-align:left;">
                        <asp:Label ID="Label19" runat="server" CssClass="control-label" />
                     </div>    
                     <div class="col-sm-9" style="text-align:center">                          
                        <asp:Label ID="lblCseDt1" runat="server"  CssClass="control-label" ForeColor="Blue"></asp:Label>
                     </div>
                </div>
          
        </div>
        </div>
          <%-- <br />--%>
           <%--Buttons Setup Div --%>
           <div id="div2" runat="server" style="width: 98%;">
         <div class="row">
                <div class="col-md-12" style="text-align: center">
                        <input id="hidFlag" runat="server" type="hidden" />&nbsp;
                             <asp:LinkButton ID="btnUpdate" runat="server"  CssClass="btn btn-success" 
                              CausesValidation="false" OnClick="btnUpdate_Click" TabIndex="14" OnClientClick="return validate();" >
                                  <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon" style="color:White"> </span> Update
                                </asp:LinkButton>&nbsp;
                        
                             <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-success" OnClick="btnSave_Click" OnClientClick="return validate();" 
                              CausesValidation="false"   TabIndex="14">
                                  <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon" style="color:White"> </span> Save
                                </asp:LinkButton>&nbsp;

                             <asp:LinkButton ID="Cancel" runat="server"   style="background-color:#FFF;color:#f04e5e; width:85px !important" CssClass="btn btn-clear" 
                              CausesValidation="false" OnClick="Cancel_Click" TabIndex="15">  
                                  <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:#f04e5e"> </span> Cancel
                                </asp:LinkButton>
                                    
                             <asp:LinkButton ID="btnshowHist" runat="server" CssClass="btn btn-danger" OnClientClick="funPopUp();return false;"
                        CausesValidation="false" TabIndex="15">
                        <span class="glyphicon glyphicon-dashboard" style="color:White"> </span> View History
                        </asp:LinkButton>
               </div>
           
         </div>
        </div>
           </center>

    <%--Modal popup Setup  --%>
    <div class="modal" id="myModal" role="dialog" style="display: none; margin-top: 53px;">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: white !important;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Style="font-weight: bold; color: #00cccc;margin-left:100px"></asp:Label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" >
                   
                         <button type="button" class="btn btn-success" data-dismiss="modal" style='margin-right:125px;' onclick="Closepopup();">
                        <span class="glyphicon glyphicon-ok glyphicon" style='color: White;'></span>OK
                    </button>
                   

                </div>
            </div>

        </div>
        </div>
    </div>

    <%--Modal popup Setup Div  --%>
    <asp:Panel runat="server" ID="PnlPopupLOB" Width="1000px" Height="550px" display="none" top="52" left="529px">
        <iframe runat="server" id="IframeLOB" width="100%" frameborder="0" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDLOB"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <asp:HiddenField ID="hdnprodctcode" runat="server" />
    <asp:HiddenField ID="hdnprodctNmae" runat="server" />
    <asp:HiddenField ID="hdn1" runat="server" />
    <asp:HiddenField ID="hdn2" runat="server" />
    <asp:HiddenField ID="hdn3" runat="server" />
    <asp:HiddenField ID="hdnprdcode" runat="server" />
    <asp:HiddenField ID="hdnProdcodeEdit" runat="server" />
    <asp:HiddenField ID="hdnChntype" runat="server" />
    <%-- </contenttemplate> 
       </asp:UpdatePanel> --%>

    <%--/*need to reomve*/--%>
   <%-- <script type="text/javascript">
        $(function () {
            $("[id*=CheckBox1]").click(function () {
                if ($(this).is(":checked")) {
                    $("[id*=txtCseDt1]").removeAttr("disabled");
                    //$("[id*=txtCseDt1]").focus();
                } else {
                    $("[id*=txtCseDt1]").attr("disabled", "disabled");
                }
            });
        });
    </script>--%>
    <script type="text/javascript">
        hideRadioSymbol();
        function hideRadioSymbol() {
            debugger;
            var rads = new Array();
            rads = document.getElementsByName('ctl00$ContentPlaceHolder1$rbCorrection'); //Whatever ID u have given to ur radiolist.
            for (var i = 0; i < rads.length; i++)
                document.getElementById(rads.item(i).id).style.display = 'none'; //hide
        }
       
    </script>
    <script type='text/javascript'>
        $(function () {
            debugger;
             $("[id*=txtIncorporation]").attr("readonly", true);
            $("[id*=txtIncorporation]").attr.backgroundColor = "white";
            $("[id*=txtEffDate]").attr("readonly", true);
            $("[id*=txtEffDate]").attr.backgroundColor = "white";
            //$("[id*=txtCseDt1]").attr("readonly", true);
            //$("[id*=txtCseDt1]").attr.backgroundColor = "white";
            $("[id*=txtCseDt]").attr("readonly", true);
            $("[id*=txtCseDt]").attr.backgroundColor = "white";
           
        })
    </script>

    
</asp:Content>
