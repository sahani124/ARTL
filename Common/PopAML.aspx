<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopAML.aspx.cs" Inherits="Application_Common_PopAML"  %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />

 <html xmlns="http://www.w3.org/1999/xhtml" >
<script type="text/javascript" src="~/Scripts/common.js"></script>
<script type="text/javascript" src="~/Scripts/subModal.js"></script>
<script type="text/javascript" src="~/Scripts/formatting.js"></script>

<script language="javascript" type="text/javascript">
var path = "<%=Request.ApplicationPath.ToString()%>";

function isEmpty(str)
{
	if ((str==null) || (str=="") || (str==" "))
		return true;
	return false;	
}

function isBlank(str)
{
   {
     if ((str==null) || (str==""))
		return true;
	 
     for (j = 0; j < str.length;  j++)
	 {  ch = str.charAt(j);
	    if (ch != " ")
			return false;
	 }
     return true;
   }
}

function isAllClear()
{
    if (
        (document.getElementById("<%=ddlReasonCD.ClientID%>").value == "") &&
        (document.getElementById("<%=ddlProofIncome.ClientID%>").value == "") &&
        (document.getElementById("<%=ddlProofAddr.ClientID%>").value == "") &&
        (document.getElementById("<%=ddlProofId.ClientID%>").value == "") &&
        (document.getElementById("<%=txtIDNo.ClientID%>").value == "") &&
        (document.getElementById("<%=txtIdIssueAuth.ClientID%>").value == "") &&
        (document.getElementById("<%=dtpIssue.ClientID%>" + "_txtDate").value == "") &&
        (document.getElementById("<%=chkPhoto.ClientID%>").checked == false) &&
        (document.getElementById("<%=ddlRiskInd.ClientID%>").value == ""))
    {
        return true;   
    }
    else
    {
        return false;
    }
}
//Commented by Anoop on 20-11-2007
//function doSave(proofage, chgwghtreason, proofincome, proofaddr, proofid, idissueauth, idno, idissuedate, chkphoto, proofphtid,riskind)
//End of Comment

//Added By Saurabh Nayar On 20071126
function funValidateOnSave()
{
	if(document.getElementById("<%= hdnIncProof.ClientID %>").value == "Y")
	{
		if(document.getElementById("<%= ddlProofIncome.ClientID %>").selectedIndex == 0)
		{
			alert("Please Select Income Proof.");
			document.getElementById("<%= ddlProofIncome.ClientID %>").focus();
			return false;
		}
	}	
	if(document.getElementById("<%= hdnAddProof.ClientID %>").value == "Y")
	{
		if(document.getElementById("<%= ddlProofAddr.ClientID %>").selectedIndex == 0)
		{
			alert("Please Select Address Proof.");
			document.getElementById("<%= ddlProofAddr.ClientID %>").focus();
			return false;
		}
	}

		if(document.getElementById("<%= hdnPermAddProof.ClientID %>").value == "Y")
		{
			if(document.getElementById("<%= ddlPermProofAddr.ClientID %>").selectedIndex == 0)
			{
				alert("Please Select Permanent Address Proof.");
				document.getElementById("<%= ddlPermProofAddr.ClientID %>").focus();
				return false;
			}
		}
	
	if(document.getElementById("<%= hdnReason.ClientID %>").value == "1")
		{
			if(document.getElementById("<%= ddlReasonCD.ClientID %>").selectedIndex == 0)
			{
				alert("Please Select Reason Code.");
				document.getElementById("<%= ddlReasonCD.ClientID %>").focus();
				return false;
			}
		}
		
	
	if(document.getElementById("<%= hdnIDProof.ClientID %>").value == "Y")
	{
		if(document.getElementById("<%= ddlProofId.ClientID %>").selectedIndex == 0)
		{
			alert("Please Select Identity Proof.");
			document.getElementById("<%= ddlProofId.ClientID %>").focus();
			return false;
		}
	}	
	if(document.getElementById("<%= hdnIDNo.ClientID %>").value == "Y")
	{
		if(isBlank(document.getElementById("<%= txtIDNo.ClientID %>").value))
		{
			alert("Please Enter Identity Number.");
			document.getElementById("<%= txtIDNo.ClientID %>").focus();
			return false;
		}
	}
	if(document.getElementById("<%= hdnIssuAuth.ClientID %>").value == "Y")
	{
		if(isBlank(document.getElementById("<%= txtIdIssueAuth.ClientID %>").value))
		{
			alert("Please Enter Issue Authority.");
			document.getElementById("<%= txtIdIssueAuth.ClientID %>").focus();
			return false;
		}
	}	
	if(document.getElementById("<%= hdnIssuDate.ClientID %>").value == "Y")
	{
		if(isBlank(document.getElementById("dtpIssue_txtDate").value))
		{
			alert("Please Enter Issue Date.");
			document.getElementById("dtpIssue_txtDate").focus();
			return false;
		}
	}	
	if(document.getElementById("<%= hdnPhotos.ClientID %>").value == "Y")
	{
		if(!(document.getElementById("<%= chkPhoto.ClientID %>").checked))
		{
			alert("Photos Is Mandatory For Risk Indicator- " + document.getElementById("<%= ddlRiskInd.ClientID %>").value);
			document.getElementById("<%= chkPhoto.ClientID %>").focus();
			return false;
		}
	}
	return true;	
}
//End Of Addition By Saurabh Nayar On 20071126

function doSave(chgwghtreason, proofincome, proofaddr, permproofaddr,proofid, idissueauth, idno, idissuedate, chkphoto, riskind)
{
    //Commented & Added By Saurabh Nayar On 20071117
    //if (Page_ClientValidate() || isAllClear())
    if (funValidateOnSave())
    //End Of Addition By Saurabh Nayar On 20071117
    { 
		if(Page_ClientValidate())
		{
			window.parent.document.getElementById(chgwghtreason).value = doEncodeToParent(document.getElementById("ddlReasonCD").value);
			window.parent.document.getElementById(proofincome).value = doEncodeToParent(document.getElementById("ddlProofIncome").value);
			window.parent.document.getElementById(proofaddr).value = doEncodeToParent(document.getElementById("ddlProofAddr").value);
			window.parent.document.getElementById(permproofaddr).value = doEncodeToParent(document.getElementById("ddlPermProofAddr").value);	//Added By Saurabh Nayar On 20071126
			window.parent.document.getElementById(proofid).value = doEncodeToParent(document.getElementById("ddlProofId").value);
			window.parent.document.getElementById(idissueauth).value = doEncodeToParent(document.getElementById("txtIdIssueAuth").value);
			window.parent.document.getElementById(idno).value = doEncodeToParent(document.getElementById("txtIDNo").value);
			window.parent.document.getElementById(idissuedate).value = doEncodeToParent(document.getElementById("dtpIssue_txtDate").value);
			window.parent.document.getElementById(chkphoto).value = document.getElementById("chkPhoto").checked;
			//Commented by Anoop on 20-11-2007
			//window.parent.document.getElementById(proofphtid).value = doEncodeToParent(document.getElementById("ddlProofPhtId").value);
			//End of Comment
			window.parent.document.getElementById(riskind).value = doEncodeToParent(document.getElementById("ddlRiskInd").value);
			window.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtAMLFlag').value = "1";
			window.parent.window.hidePopWin(false);
		}
    }   
}

function doClear()
{
    var answer = confirm("Are you sure want to clear all?")

    if (answer!=0) 
    {
        document.getElementById("<%=ddlReasonCD.ClientID%>").value = "";
        document.getElementById("<%=ddlProofIncome.ClientID%>").value = "";
        document.getElementById("<%=ddlProofAddr.ClientID%>").value = "";
        document.getElementById("<%=ddlPermProofAddr.ClientID%>").value = "";	//Added By Saurabh Nayar On 20071126
        document.getElementById("<%=ddlProofId.ClientID%>").value = "";
        document.getElementById("<%=txtIDNo.ClientID%>").value = "";
        document.getElementById("<%=txtIdIssueAuth.ClientID%>").value = "";
        document.getElementById("<%=dtpIssue.ClientID%>" + "_txtDate").value = "";
        document.getElementById("<%=chkPhoto.ClientID%>").checked = false;
//        document.getElementById("<%=ddlRiskInd.ClientID%>").value = "";
    }
}

function doCancel()
{
    var answer = confirm("Are you sure want to exit without saving?")

    if (answer!=0) 
    {
        //Commented by Anoop Goel on 20-11-2007
        //if(document.getElementById("ddlProofAge").value == "" || document.getElementById("ddlProofId").value == "" || document.getElementById("ddlProofIncome").value == "" || document.getElementById("ddlProofAddr").value == "" || document.getElementById("txtIdIssueAuth").value == "" || document.getElementById("txtIDNo").value == "" || document.getElementById("dtpIssue_txtDate").value == "" || document.getElementById("ddlRiskInd").value == "")
        //End of Comment
        if(document.getElementById("ddlProofId").value == "" || document.getElementById("ddlProofIncome").value == "" || document.getElementById("ddlProofAddr").value == "" || document.getElementById("txtIdIssueAuth").value == "" || document.getElementById("txtIDNo").value == "" || document.getElementById("dtpIssue_txtDate").value == "" || document.getElementById("ddlRiskInd").value == "")
        {
            window.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtAMLFlag').value = "";
        }    
        window.parent.window.hidePopWin(false);
    }
}

function doInit()
{
    document.getElementById("ddlReasonCD").value = window.parent.document.getElementById('<%=Request.QueryString["ChgWghtReason"].ToString()%>').value.trim();
    document.getElementById("ddlProofIncome").value = window.parent.document.getElementById('<%=Request.QueryString["ProofIncome"].ToString()%>').value.trim();
    document.getElementById("ddlProofAddr").value = window.parent.document.getElementById('<%=Request.QueryString["ProofAddr"].ToString()%>').value.trim();
    document.getElementById("ddlPermProofAddr").value = window.parent.document.getElementById('<%=Request.QueryString["PermProofAddr"].ToString()%>').value.trim();	//Added By Saurabh Nayar On 20071126
    document.getElementById("ddlProofId").value = window.parent.document.getElementById('<%=Request.QueryString["ProofID"].ToString()%>').value.trim();
    document.getElementById("txtIdIssueAuth").value = window.parent.document.getElementById('<%=Request.QueryString["IdIssueAuth"].ToString()%>').value.trim();
    document.getElementById("txtIDNo").value = window.parent.document.getElementById('<%=Request.QueryString["IDNo"].ToString()%>').value.trim();
    document.getElementById("dtpIssue_txtDate").value = window.parent.document.getElementById('<%=Request.QueryString["IdIssueDate"].ToString()%>').value.trim();
    
    //document.getElementById("ddlRiskInd").value = window.parent.document.getElementById('<%=Request.QueryString["RiskInd"].ToString()%>').value.trim();
    
    var photo = window.parent.document.getElementById('<%=Request.QueryString["chkPhoto"].ToString()%>').value;
    if (photo.toLowerCase() == "true")
    {  
        document.getElementById("chkPhoto").checked = window.parent.document.getElementById('<%=Request.QueryString["chkPhoto"].ToString()%>').value;
    }
    
}

</script>

<head runat="server" >
    <title>Address</title>
</head>
<body>
    <form defaultfocus="txtHeight" id="form1" runat="server" style=" width: auto; height:auto;">
    <asp:ScriptManager runat="server" ID="scriptmgr">
        <Scripts>
            <asp:ScriptReference Path="Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference  Path="Lookup.asmx" />
        </Services>            
    </asp:ScriptManager>
    <div>
        <table class="formtable" width="700px">
            <tr>
                <td class="formcontent" style="height: 20px" width="150">
                    <asp:Label ID="lblRiskInd" runat="server"></asp:Label>
                    </td>
                <td class="formcontent" style="height: 20px" width="300">
                    <asp:DropDownList ID="ddlRiskInd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRiskInd_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRiskInd"
                        Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="true"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr>
                <td class="formcontent" width="150px"><span>
                <asp:Label ID="lblRes" runat="server"></asp:Label>
                </span><asp:Label id="lblReason" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                <td class="formcontent"  width="300px">
                    <%-- <asp:TextBox ID="txtChgWghtReason" runat="server" CssClass="standardtextbox" MaxLength="50" Width="138px"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlReasonCD" runat="server"></asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator ID="rfvChgWghtReason" runat="server" SetFocusOnError="true" Enabled="false" Display="None" ControlToValidate="ddlReasonCD" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%></td>
            </tr>
            
            <%--Commented by Anoop on 20-11-2007--%>
            
            <%--<tr>
                <td class="formcontent"  width="150px" style="height: 24px"><span>Age Proof <font color="Red">*</font></span></td>
                <td class="formcontent"  width="300px" style="height: 24px">
                    <asp:DropDownList ID="ddlProofAge" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProofAge" runat="server" SetFocusOnError="true" Enabled="true" Display="Dynamic" ControlToValidate="ddlProofAge" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>
            </tr>--%>
            
            <%--End of Comment--%>
            
            <tr>
                <td class="formcontent" width="150px">
                <span><asp:Label ID="lblIncmProof" runat="server"></asp:Label> </span> <asp:Label id="lblIncProof" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                <td class="formcontent"  nowrap="nowrap">
                    <asp:DropDownList ID="ddlProofIncome" runat="server" CausesValidation="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="formcontent" width="150px" style="height: 23px">
                <span><asp:Label ID="lblAddProof" runat="server"></asp:Label> </span> <asp:Label id="lblAddrProof" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                <td class="formcontent" nowrap="nowrap" style="height: 23px">
                    <asp:DropDownList ID="ddlProofAddr" runat="server" CausesValidation="true" ></asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator ID="rfvProofAddr" runat="server" SetFocusOnError="true" Enabled="true" Display="Dynamic" ControlToValidate="ddlProofAddr" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr>
                <td class="formcontent" width="150px" style="height: 23px">
                <span><asp:Label ID="lblPermAddProof" runat="server"></asp:Label></span> <asp:Label ID="lblPermAddrProof" runat="server"
						ForeColor="Red" Text="*" Visible="false"></asp:Label></td>
                <td class="formcontent" nowrap="nowrap" style="height: 23px">
                    <asp:DropDownList ID="ddlPermProofAddr" runat="server" CausesValidation="true" ></asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator ID="rfvProofAddr" runat="server" SetFocusOnError="true" Enabled="true" Display="Dynamic" ControlToValidate="ddlProofAddr" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr>
                <td class="formcontent" width="150px" style="height: 23px"><span>
                <asp:Label ID="lblIDProf" runat="server"></asp:Label>
                </span> <asp:Label id="lblIDProof" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                <td class="formcontent" nowrap="nowrap" style="height: 23px">
                    <asp:DropDownList ID="ddlProofId" runat="server" CausesValidation="true" ></asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator ID="rfvProofId" runat="server" SetFocusOnError="true" Enabled="true" Display="Dynamic" ControlToValidate="ddlProofId" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr>
                <td class="formcontent"><span>
                <asp:Label ID="lblIdentity" runat="server"></asp:Label>
                 </span> <asp:Label id="lblIDNo" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox ID="txtIDNo" runat="server" CssClass="standardtextbox"  MaxLength="20" Width="188"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="rfvIDNo" runat="server" SetFocusOnError="true" Enabled="true" Display="Dynamic" ControlToValidate="txtIDNo" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr>
                <td class="formcontent" width="150px"><span>
                <asp:Label ID="lblIssAuthority" runat="server"></asp:Label>
                </span> <asp:Label id="lblIssAuth" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox ID="txtIdIssueAuth" runat="server" CssClass="standardtextbox" MaxLength="30" Width="188"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="rfvIdIssueAuth" runat="server" SetFocusOnError="true" Enabled="true" Display="Dynamic" ControlToValidate="txtIdIssueAuth" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%></td>
            </tr>            
            <tr>
                <td class="formcontent"><span>
                <asp:Label ID="lblIssDate" runat="server"></asp:Label>
                </span> <asp:Label id="lblIssDt" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                <td class="formcontent"  ="nowrap">
                    <uc1:ctlDate ID="dtpIssue" runat="server" RequiredField="true" /></td>
            </tr>              
           
           <%--Commented by Anoop on 20-11-2007--%>
           
           <%-- <tr>     
                <td class="formcontent">Photo Id Proof <font color="Red">*</font></td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:DropDownList ID="ddlProofPhtId" runat="server"  CausesValidation="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProofPhtId" runat="server" SetFocusOnError="true" Enabled="true" Display="Dynamic" ControlToValidate="ddlProofPhtId" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>
            </tr>--%>
            
            <%--End of Comment--%>
            
            <tr>
                <td class="formcontent" colspan="2" nowrap="nowrap">
					<asp:Label id="lblPhoto" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label>
                    <asp:CheckBox ID="chkPhoto" runat="server" Text="Photos" TextAlign="Left" /></td>
            </tr>
            <tr>
                <td class="formcontent" align="center" colspan="2" style=" text-align: center">
                    <asp:Button CssClass="standardbutton"  ID="btnSave" runat="server" Text="Save" CausesValidation="true" Width="60px" OnClick="btnSave_Click" /><asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" Width="60px" OnClientClick="doClear();return false;" /><asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel" OnClientClick="doCancel();return false;" /></td>
					<asp:HiddenField runat="server" id="hdnIncProof" />
					<asp:HiddenField runat="server" id="hdnAddProof" />
					<asp:HiddenField runat="server" id="hdnIDProof" />
					<asp:HiddenField runat="server" id="hdnIDNo" />
					<asp:HiddenField runat="server" id="hdnIssuAuth" />
					<asp:HiddenField runat="server" id="hdnIssuDate" />
					<asp:HiddenField runat="server" id="hdnPhotos" />
					<asp:HiddenField runat="server" id="hdnReason" />
					<%-- Added By Saurabh Nayar On 20071126 --%>
					<asp:HiddenField runat="server" id="hdnPermAddProof" />
					<%-- End Of Addition By Saurabh Nayar On 20071126 --%>
            </tr>
        </table>
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
    doInit();
</script>
</html>
