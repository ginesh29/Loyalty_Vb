<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="CustSearchAdvanced.aspx.vb" Inherits="CustomerReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            text-decoration: underline;
        }
        .style8
        {
            height: 33px;
        }
        .style10
        {
            height: 33px;
            width: 74px;
        }
        .style13
        {
        }
        .style14
        {
    }
        .style15
        {
            height: 24px;
        }
    .style16
    {
        width: 54px;
    }
        .style17
        {
            width: 68px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table>
    <tr>
        <td class="style7" colspan="2">
            Reports --&gt; Advanced Cust Search</td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" BackColor="AliceBlue" 
                BorderStyle="Groove">
                <table>
                    <tr>
                        <td class="style14" colspan="2" align="center">
                            Customer Search</td>
                    </tr>
                    <tr>
                        <td align="center" class="style14" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style14" colspan="2">
                            Cust No/Mobile No:</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtCardNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style14">
                            Gender:</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButtonList ID="rbListGender" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">All</asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="0">Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Card Purchase/Entry Dt:</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtPurDt" runat="server"></asp:TextBox>
                        
                        <asp:CalendarExtender ID="CEPurDt"  Format="dd/MM/yyyy" runat="server" TargetControlID="txtPurDt">
                        </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            </td>
                        <td class="style15">
                            </td>
                    </tr>
                    <tr>
                        <td class="style15" colspan="2">
                            <asp:CheckBox ID="chkEarnedPoints" runat="server" 
                                Text="Top Purchased Customers" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" colspan="2">
                            <asp:CheckBox ID="chkCardNotIssued" runat="server" Text="Card Not Issued" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" colspan="2">
                            <asp:CheckBox ID="chkActive" runat="server" 
                                Text="Active Customers" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" colspan="2">
                            <asp:CheckBox ID="chkBL" runat="server" Text="Blacklisted Customers" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style14" valign="middle">
                            <asp:Label ID="Label1" runat="server" Text="Total Points From" Width="100px"></asp:Label>
                            </td>
                        <td valign="middle">
                            <asp:TextBox ID="txtPointsFrom" runat="server" Width="45px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            Points To</td>
                        <td class="style8">
                            <asp:TextBox ID="txtPointsTo" runat="server" Width="45px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td valign="top">
           
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table bgcolor="AliceBlue" class="style1">
                                        <tr>
                                            <td align="center" class="style16">
                                                &nbsp;</td>
                                            <td align="center" colspan="2">
                                                Group By Report</td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style16">
                                                &nbsp;</td>
                                            <td align="center" colspan="2">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                &nbsp;</td>
                                            <td>
                                                <asp:RadioButton ID="rbNationality" runat="server" AutoPostBack="True" 
                                                    GroupName="grpBy" Text="Nationality" />
                                            </td>
                                            <td class="style17">
                                                <asp:DropDownList ID="ddlCountryGrpBy" runat="server" Enabled="False" 
                                                    Width="160px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                &nbsp;</td>
                                            <td>
                                                <asp:RadioButton ID="rbCardType" runat="server" AutoPostBack="True" 
                                                    GroupName="grpBy" Text="Card Type" />
                                            </td>
                                            <td class="style17">
                                                <asp:DropDownList ID="ddlCustGrpGrpBy" runat="server" Enabled="False" 
                                                    Width="160px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                &nbsp;</td>
                                            <td>
                                                <asp:RadioButton ID="rbCustCompany" runat="server" AutoPostBack="True" 
                                                    GroupName="grpBy" Text="Company" />
                                            </td>
                                            <td class="style17">
                                                <asp:DropDownList ID="ddlCompanyAll" runat="server" Enabled="False" 
                                                    Width="160px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                &nbsp;</td>
                                            <td>
                                                <asp:RadioButton ID="rbCustAccmnArea" runat="server" AutoPostBack="True" 
                                                    GroupName="grpBy" Text="Accmdn Area" />
                                            </td>
                                            <td class="style17">
                                                <asp:DropDownList ID="ddlAccAreaGrpBy" runat="server" Enabled="False" 
                                                    Width="160px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                &nbsp;</td>
                                            <td>
                                                <asp:RadioButton ID="rbReligion" runat="server" AutoPostBack="True" 
                                                    GroupName="grpBy" Text="Religion" Visible="False" />
                                            </td>
                                            <td class="style17">
                                                <asp:DropDownList ID="ddlReligionGrpBy" runat="server" Enabled="False" 
                                                    Width="160px" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td class="style17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
           
            </td>
    </tr>
    <tr>
        <td>
                            <asp:Button ID="btnShowReport" runat="server" 
                Text="Show Report" Height="28px" Width="120px" />
                        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
    
</asp:Content>

