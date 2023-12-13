<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateLink.aspx.cs" Inherits="Application_Isys_Recruit_GenerateLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate Link For Applicant</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <style>
        body {
            background-color: whitesmoke;
        }

        .PanelInsideTab {
            margin: 2% 5%;
            padding: 1%;
            background-color: white;
            height:auto;
        }

        .smallspace {
            margin-top: 2%;
        }

        p {
            margin-left: 2rem;
            margin-bottom: 0 !important;
        }

        @media (min-width: 768px) {
            .PanelInsideTab {
                margin: 3% 20%;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="PanelInsideTab card" style="overflow-y:auto">
            <div class="row">
                <div class="col-sm-10">
                    <asp:Label ID="lblHeader" runat="server" Text="Applicant's Contact Details" CssClass="control-label HeaderColor" Style="margin-left: 12px;"></asp:Label>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row rowspacing">
                            <div class="col-sm-12">
                                <asp:Label ID="lblapplink" runat="server" Text="Send Application Link" CssClass="control-label"></asp:Label>
                                <asp:DropDownList ID="ddlaaplink" runat="server" CssClass="form-control form-select smallspace"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row rowspacing">
                            <div class="col-sm-12">
                                <asp:Label ID="lblAppName" runat="server" Text="Send Applicant's Name" CssClass="control-label"></asp:Label>
                                <asp:TextBox ID="txtAppName" runat="server" CssClass="form-control smallspace"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row rowspacing">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMobNo" runat="server" Text="Mobile No" CssClass="control-label"></asp:Label>
                                <asp:TextBox ID="txtMobNo" runat="server" CssClass="form-control smallspace"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row rowspacing">
                            <div class="col-sm-12">
                                <asp:Label ID="lblEmailID" runat="server" Text="Email ID" CssClass="control-label"></asp:Label>
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control smallspace"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row rowspacing">
                            <div class="col-sm-12" style="text-align:center;">
                                <asp:Label ID="lblshare" runat="server" Text="HTTPS://bit.ly/3ji3GvB" style="color:#00cccc"></asp:Label>
                            </div>
                        </div>
                        <div class="d-flex justify-content-center rowspacing">
                            <asp:LinkButton ID="lknbtn" runat="server" Text="SHARE" OnClick="lknbtn_Click" CssClass="btn btn-success" style="width: 25% !important; max-width: 200px;"></asp:LinkButton>
                        </div>
                        <p class="rowspacing">
                            The Application (Reference Number: 10012189)<br/>
                            is now pending with the applicant.            
                        </p>
                        <p>
                            A web link shared with the applicant.        
                        </p>
                        <hr />
                        <div class="row rowspacing">
                            <div class="col-sm-12" style="text-align:center;">
                                <asp:Label ID="lbllnkAndroid" runat="server" Text="HTTPS://bit.ly/3ji3GvB" style="color:#00cccc"></asp:Label>
                            </div>
                        </div>
                        <div class="d-flex justify-content-center rowspacing">
                            <asp:LinkButton ID="lknbtnAndroid" runat="server" Text="SHARE" CssClass="btn btn-success" style="width: 25% !important; max-width: 200px;"></asp:LinkButton>
                        </div>
                        <p class="rowspacing">
                            The Application (Reference Number: 10012189)<br/>
                            is now pending with the applicant.            
                        </p>
                        <p>
                            An Android application link shared with the applicant.        
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>


<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateLink.aspx.cs" Inherits="Application_Isys_Recruit_GenerateLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: whitesmoke;">
<head runat="server">
    <title>Generate Link For Applicant</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <style>
        .PanelInsideTab {
            margin-left: 13%;
            margin-right: 13%;
            margin-top: 2%;
            padding: 1%;
            background-color: white;
        }

        .smallspace {
            margin-top: 2%;
        }
        p{
            margin-left:110px;
            margin-bottom:0px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="PanelInsideTab card">
            <div class="row">
                <div class="col-sm-10">
                    <asp:Label ID="lblHeader" runat="server" Text="Applicant's Contact Deatils" CssClass="control-label HeaderColor" Style="margin-left: 35px;"></asp:Label>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="row rowspacing">
                        <div class="col-sm-6">
                            <asp:Label ID="lblapplink" runat="server" Text="Send Application Link" CssClass="control-label"></asp:Label>
                            <asp:DropDownList ID="ddlaaplink" runat="server" CssClass="form-control form-select smallspace"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row rowspacing">
                        <div class="col-sm-6">
                            <asp:Label ID="lblAppName" runat="server" Text="Send Applicant's Name" CssClass="control-label"></asp:Label>
                            <asp:TextBox ID="txtAppName" runat="server" CssClass="form-control smallspace"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row rowspacing">
                        <div class="col-sm-6">
                            <asp:Label ID="lblMobNo" runat="server" Text="Mobile No" CssClass="control-label"></asp:Label>
                            <asp:TextBox ID="txtMobNo" runat="server" CssClass="form-control smallspace"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row rowspacing">
                        <div class="col-sm-6">
                            <asp:Label ID="lblEmailID" runat="server" Text="Email ID" CssClass="control-label"></asp:Label>
                            <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control smallspace"></asp:TextBox>
                        </div>
                    </div>
                    </div>
                    <div class="col-lg-6">
                                                 <div class="row rowspacing">
                    <div class="col-sm-12" style="text-align:center;">
                        <asp:Label ID="lblshare" runat="server" Text="HTTPS://bit.ly/3ji3GvB" style="color:#00cccc"></asp:Label>
                    </div>


                </div>
                   
                        <div class="d-flex justify-content-center rowspacing">
                <asp:LinkButton ID="lknbtn" runat="server" Text="SHARE" CssClass="btn btn-success" style="width: 25% !important; max-width: 200px;"></asp:LinkButton>
            </div>
                       <p class="rowspacing" style="margin-left:110px">
                     The Application (Reference Number: 10012189)<br/>
                              </p>
                        <p style="margin-left:155px">
                             is now pending with applicant.            
                            </p>
                        <p style="margin-left:140px">
                     A web link shared with applicant.        
                                 </p>      
                        <hr />
                              <div class="row rowspacing">
                    <div class="col-sm-12" style="text-align:center;">
                        <asp:Label ID="lbllnkAndroid" runat="server" Text="HTTPS://bit.ly/3ji3GvB" style="color:#00cccc"></asp:Label>
                    </div>


                </div>
                   
                        <div class="d-flex justify-content-center rowspacing">
                <asp:LinkButton ID="lknbtnAndroid" runat="server" Text="SHARE" CssClass="btn btn-success" style="width: 25% !important; max-width: 200px;"></asp:LinkButton>
            </div>
                       <p class="rowspacing" style="margin-left:110px">
                     The Application (Reference Number: 10012189)<br/>
                              </p>
                        <p style="margin-left:155px">
                             is now pending with applicant.            
                            </p>
                        <p >
                     A android application link shared with applicant.        
                                 </p>   
                        </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>--%>
