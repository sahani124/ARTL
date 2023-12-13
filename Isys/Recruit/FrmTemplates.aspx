<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="FrmTemplates.aspx.cs" Inherits="Application_ISys_Recruit_FrmTemplates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <table id="tblTemplate" runat="server" width="100%" align="center">
        <tr>
            <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #f3255e;">
                    <table align="center" style="width: 90%">
                        <tr style="height: 20%">
                            <%--<td style="width: 20%" align="center">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="lblFrmVA1" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px;"></i>
                            </td>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="lblTrnsfr" runat="server" Font-Size="Medium" ForeColor="White" Text="Form 1 A"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #f20d4d; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#da0c45';" onmouseout="this.style.background='#f20d4d';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbFrmVA" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lbFrmVA_Click"></asp:LinkButton>
                </div>
            </td>
            <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #28b779;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="lblVATrnsfr" runat="server" Font-Size="Medium" ForeColor="White" Text="Form 1B"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #28b779; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#10a062';" onmouseout="this.style.background='#28b779';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkVATrnsfr" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkVATrnsfr_Click"></asp:LinkButton>
                </div>
            </td>
            <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #852b99;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <td rowspan="2" style="width: 20%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5;"></i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblVARnwl" runat="server" Font-Size="Medium" ForeColor="White" Text="CODE OF CONDUCT"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #852b99; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#6e1881';" onmouseout="this.style.background='#852b99';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkVARnwl" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkVARnwl_Click"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <!--you just need a space in a row-->
            </td>
        </tr>
        <tr>
            <td style="width: 25%;">
                <div style="height: 80px; width: 300px; background-color: #FF33CC;">
                    <table align="center" style="width: 90%">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="right">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label4" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height: 90%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px;"></i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblAdvsr" runat="server" Font-Size="Medium" ForeColor="White" Text="Insurance Advisors Application Form"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #FF33CC; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#CC0099';" onmouseout="this.style.background='#FF33CC';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkAdvsr" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkAdvsr_Click"></asp:LinkButton>
                </div>
            </td>
            <td style="width: 25%;">
                <div style="height: 80px; width: 300px; background-color: #ffb848;">
                    <table align="center" style="width: 90%; height: 75px">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label3" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height: 90%; color: Black;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px; color: White;">
                                </i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblNEFTFrm" runat="server" Font-Size="Medium" ForeColor="White" Width="200px"
                                    Text="Combo NEFT Mandate Form"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #ffb848; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#cb871b';" onmouseout="this.style.background='#ffb848';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkNEFTFrm" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkNEFTFrm_Click"></asp:LinkButton>
                </div>
            </td>
            <td style="width: 25%;">
                <div style="height: 80px; width: 300px; background-color: #04F0D5;">
                    <table align="center" style="width: 90%; height: 75px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="right">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label4" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height: 90%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px;"></i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblRepeater" runat="server" Font-Size="Medium" ForeColor="White" Text="Repeater Form"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #04F0D5; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#02D2BA';" onmouseout="this.style.background='#04F0D5';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkRepeater" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkRepeater_Click"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <!--you just need a space in a row-->
            </td>
        </tr>
        <tr>
            <td style="width: 25%;">
                <div style="height: 80px; width: 300px; background-color: #0E8FB6;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="right">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label4" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height:30%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px;"></i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblUserManualSM" runat="server" Font-Size="Medium" ForeColor="White"
                                    Text="User Manual for SM"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #0E8FB6; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#056784';" onmouseout="this.style.background='#0E8FB6';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkUsrManualSM" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkUsrManualSM_Click"></asp:LinkButton>
                </div>
            </td>
            <td style="width: 25%;">
                <div style="height: 80px; width: 300px; background-color: #0D52E6;">
                    <table align="center" style="width: 90%">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label3" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height: 90%; color: Black;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px; color: White;">
                                </i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblUserManualRnwl" runat="server" Font-Size="Medium" ForeColor="White"
                                    Width="200px" Text="User Manual for License Renewal"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #0D52E6; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#0A3FB0';" onmouseout="this.style.background='#0D52E6';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkUsrManualRnwl" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkUsrManualRnwl_Click"></asp:LinkButton>
                </div>
            </td>
            <td style="width: 25%;">
                <div style="height: 80px; width: 300px; background-color: #EFE11B;">
                    <table align="center" style="width: 90%; height: 75px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="right">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label4" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height: 90%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px;"></i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblUsrManualReExm" runat="server" Font-Size="Medium" ForeColor="White"
                                    Text="User Manual for Re-Examination"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #EFE11B; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#CEC112';" onmouseout="this.style.background='#EFE11B';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkUsrManualReExm" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkUsrManualReExm_Click"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <!--you just need a space in a row-->
            </td>
        </tr>
        <tr>
            <td style="width: 25%;">
                <div style="height: 80px; width: 300px; background-color: #b6350e;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="right">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label4" runat="server"></asp:Label>
                            </td>--%>
                            <td rowspan="2" style="width: 20%; height: 30%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 30px;"></i>
                            </td>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="lblUsrMnlSMAlloc" runat="server" Font-Size="Medium" ForeColor="White" Text="User Manual for SM Allocation"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #b6350e; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#f05829';" onmouseout="this.style.background='#b6350e';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkbtnSmAllocDwnl" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" 
                        onclick="lnkbtnSmAllocDwnl_Click"></asp:LinkButton>
                </div>
            </td>
            <%--Added by Nikhil on 22-4-15 for AppInsAgtD Download--%>
              <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #808000;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="White" Text="Sponsorship Form_Individual"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #808000; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#669900';" onmouseout="this.style.background='#808000';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="InkAppDwld" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkAppDwld_Click"></asp:LinkButton>
                </div>
            </td>
            <%--Ended by Nikhil--%>
              <%--Added by usha on 15-10-15 for NOC Download--%>
              <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #9400D3;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                           
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                           
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label2" runat="server" Font-Size="Medium" ForeColor="White" Text="Declaration (NOC) cum Affidavit"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #9400D3; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#669900';" onmouseout="this.style.background='#9400D3';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnknoc_Click"></asp:LinkButton>
                </div>
            </td>
            <%--Ended by usha --%>
             <%--Added by Nikhil on 22-4-15 for AppInsAgtD Download--%>
             
        </tr>
          <tr>
            <td>
                &nbsp;
                <!--you just need a space in a row-->
            </td>
        </tr>
        <tr>
        <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #6600CC;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label3" runat="server" Font-Size="Medium" ForeColor="White" Text="User manual for Composite Case"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #6600CC; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#9900FF';" 
                      onmouseout="this.style.background='#6600CC';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="composite" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkcompDwld_Click"></asp:LinkButton>
                </div>
            </td>

           
            <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #FF9966;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label4" runat="server" Font-Size="Medium" ForeColor="White" Text="User manual for Transfer Case"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #FF9966; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#FF6666';" 
                      onmouseout="this.style.background='#FF9966';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="transfer" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnktranDwld_Click"></asp:LinkButton>
                </div>
            </td>
             <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #CC6600;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="lblUnderTkn" runat="server" Font-Size="Medium" ForeColor="White" Text="Undertaking from prospective Insurance Advisor"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #CC6600; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#FF9933';" 
                      onmouseout="this.style.background='#CC6600';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton12" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lblUnderTkn_Click"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <!--you just need a space in a row-->
            </td>
        </tr>
         
        <tr>
         
         <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #CC3399;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label20" runat="server" Font-Size="Medium" ForeColor="White" Text="User manual for Fresh Case"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #CC3399; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#CC0066';" 
                      onmouseout="this.style.background='#CC3399';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="fresh" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkfreshDwld_Click"></asp:LinkButton>
                </div>
            </td>

             <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #CC99FF;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label5" runat="server" Font-Size="Medium" ForeColor="White" Text=" NOC Process User manual for SM and BM "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #CC99FF; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#CC0066';" 
                      onmouseout="this.style.background='#CC3399';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnknocDwld_Click"></asp:LinkButton>
                </div>
            </td>

                 <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #FF0099;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label6" runat="server" Font-Size="Medium" ForeColor="White" Text=" NOC Process manual for Team "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #FF0099; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#CC0066';" 
                      onmouseout="this.style.background='#CC3399';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton3" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnknocteamDwld_Click"></asp:LinkButton>
                </div>
            </td>


           
        </tr>

       <%-- <tr>
            <td style="width: 25%; visibility: hidden">
                <div style="height: 80px; width: 300px; background-color: #f3255e;">
                    <table align="center" style="width: 90%">
                        <tr style="height: 20%">
                            <td style="width: 70%" align="right">
                                <asp:Label Font-Size="35px" ForeColor="White" ID="Label6" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">--%>
                                <%--<asp:Label ID="Label7" runat="server" Font-Size="Medium" ForeColor="White" Text="Insurance Advisors application form 11th Apr 2013"></asp:Label>--%>
                          <%-- </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #f20d4d; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#da0c45';" onmouseout="this.style.background='#f20d4d';">
                    &nbsp;&nbsp;&nbsp;--%>
                    <%--<asp:LinkButton ID="LinkButton2" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        runat="server" Text="View Template"></asp:LinkButton>--%>
              <%--</div>
            </td>
        </tr>--%>

      <%--  added by amruta for fees template on 15.12.15 start--%>

          <tr>
            <td>
                &nbsp;
                <!--you just need a space in a row-->
            </td>
        </tr>
        <tr>
         <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #408080;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;" 
                                bgcolor="#408080">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label7" runat="server" Font-Size="Medium" ForeColor="White" Text="User manual for Candidate Fees Pending and Fees Waiver"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #408080; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#CC0066';" 
                      onmouseout="this.style.background='#408080';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton4" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkFeesDwld_Click"></asp:LinkButton>
                </div>
            </td>
             <td style="width: 25%; height: 40%;">
                <div style="height: 80px; width: 300px; background-color: #3399FF;">
                    <table align="center" style="width: 90%; height: 85px;">
                        <tr style="height: 20%">
                            <%--<td style="width: 70%" align="center">--%>
                            <td rowspan="2" style="width: 20%; height: 40%; color: White;" 
                                bgcolor="#3399FF">
                                <i class="fa fa-share-square-o fa-5x" style="opacity: 0.5; margin-top: 5px;"></i>
                            </td>
                            <%--</td>--%>
                            <td align="right" style="width: 70%;">
                                <asp:Label ID="Label8" runat="server" Font-Size="Medium" ForeColor="White"
                                 Text="RGI-Resignation Letter-Surrender of Agency" BackColor="#3399FF"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 24px; width: 300px; background-color: #3399FF; background-repeat: no-repeat;"
                    onmouseover="this.style.background='#0066FF';" 
                      onmouseout="this.style.background='#3399FF';">
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton5" ForeColor="White" CssClass="stylink" Font-Size="13px"
                        Font-Underline="true" runat="server" Text="Template Download" OnClick="lnkResgLtr_Click"></asp:LinkButton>
                </div>
            </td>
          </tr>
         <%--  added by amruta for fees template on 15.12.15 end--%>

    </table>
</asp:Content>
