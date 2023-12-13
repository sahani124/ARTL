<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClientAML.ascx.cs" Inherits="Application_Common_ClientAML" %>
<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="~/Scripts/common.js"></script>
<script type="text/javascript" src="~/Scripts/subModal.js"></script>
<script language="javascript" type="text/javascript">
//Commented by Anoop on 20-11-2007
//function popAML(proofage, chgwghtreason, proofincome, proofaddr, proofid, idissueauth, idno, idissuedate, chkphoto, proofphtid, riskind, readonly, title)
//End of Comment
function popAML(chgwghtreason, proofincome, proofaddr, permproofaddr, proofid, idissueauth, idno, idissuedate, chkphoto, riskind, readonly, title,strGCN,strRskInd)

{
	return false; 
    //Added By Saurabh Nayar On 20071117
    //Purpose:  To Validate The Occupation Code Exists As Risk Indicator Is Populated Based On Occupation Entered By The User
    if(document.getElementById('ctl00_ContentPlaceHolder1_txtOccupationCode').value == "")
    {
        alert("Please Enter Occupation.");
        document.getElementById('ctl00_ContentPlaceHolder1_txtOccupationCode').focus();
        return false;
    }
    //End Of Addition By Saurabh Nayar On 20071117
    showPopWin(
        //Commented by Anoop on 20-11-2007
        //"PopAML.aspx?ProofAge=" + proofage +
        //End of Comment
        "PopAML.aspx?ChgWghtReason=" + chgwghtreason +
        "&ProofIncome=" + proofincome +
        "&ProofAddr=" + proofaddr +
        "&PermProofAddr=" + permproofaddr +
        "&ProofID=" + proofid +
        "&IdIssueAuth=" + idissueauth +
        "&IDNo=" + idno +
        "&IdIssueDate=" + idissuedate +
        "&chkPhoto=" + chkphoto +
        //Commented by Anoop on 20-11-2007
        //"&ProofPhtID=" + proofphtid + 
        //End of Comment
        "&RiskInd=" + riskind +
        "&ReadOnly=" + readonly +
        "&Title=" + title +
        "&GCN=" + strGCN +
        "&RskInd=" + strRskInd +
        "&Occupation=" + document.getElementById('ctl00_ContentPlaceHolder1_txtOccupationCode').value +
        "&PermAddrFlag=" + document.getElementById('ctl00_ContentPlaceHolder1_ChkPA').checked 
        , 500, 350, null);  
//        "&vHeight=" + document.getElementById(height).value +
//        "&vWeight=" + document.getElementById(weight).value +
//        "&vProofAge=" + document.getElementById(proofage).value +
//        "&vChgWghtReason=" + document.getElementById(chgwghtreason).value +
//        "&vProofIncome=" + document.getElementById(proofincome).value +
//        "&vProofAddr=" + document.getElementById(proofaddr).value +
//        "&vProofID=" + document.getElementById(proofid).value +
//        "&vIdIssueAuth=" + document.getElementById(idissueauth).value +
//        "&vIDNo=" + document.getElementById(idno).value +
//        "&vIdIssueDate=" + document.getElementById(idissuedate).value +
//        "&vchkPhoto=" + document.getElementById(chkphoto).value +
//        "&vProofPhtID=" + document.getElementById(proofphtid).value +
     
}


</script>
<asp:Button ID="btnAML" Text="AML" runat="server" />
<%--Commented by Anoop on 20-11-2007--%>
<%--<input id="hdnProofAge" runat="server" type="hidden" />--%>
<%--End of Comment--%>
<input id="hdnChgWghtReason" runat="server" type="hidden" />
<input id="hdnProofIncome" runat="server" type="hidden" />
<input id="hdnProofAddr" runat="server" type="hidden" />
<input id="hdnProofID" runat="server" type="hidden" />
<input id="hdnIdIssueAuth" runat="server" type="hidden" />
<input id="hdnIDNo" runat="server" type="hidden" />
<input id="hdnIdIssueDate" runat="server" type="hidden"/>
<input id="hdnchkPhoto" runat="server" type="hidden" />
<%--Commented by Anoop on 20-11-2007--%>
<%--<input id="hdnProofPhtID" runat="server" type="hidden" />--%>
<%--End of Comment--%>
<input id="hdnRiskInd" runat="server" type="hidden" />
<input id="hdnPermProofAddr" runat="server" type="hidden" />
<input id="hdnGCN" runat="server" type="hidden" />
