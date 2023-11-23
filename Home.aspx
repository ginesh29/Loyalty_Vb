<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
    }
    .style7
    {
        text-decoration: underline;
    }
        .style10
        {
            width: 124px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="Maroon"></asp:Label>
    <asp:Panel ID="pnlMessage" runat="server" Height="182px" Width="385px" 
        BackColor="#99CCFF">
    <table>
        <tr>
            <td class="style7" colspan="2">
                Message:</td>
            <td class="style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" Height="31px" 
                    Text="Customer Transactions in the Loyalty Server is not up to date." 
                    Width="367px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblLastUpdt" runat="server" Width="370px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                <asp:RadioButton ID="rbUpdateNow" runat="server" 
                Checked="True" Text="Update Now" GroupName="action" />
            </td>
            <td>
                <asp:RadioButton ID="rbUpdateLater" runat="server" 
                Text="Update Later" GroupName="action" Width="202px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="2" align="center">
                <asp:Button ID="btnSubmit" runat="server" Height="28px" Text="Submit" 
                    Width="90px" />
              
            </td>
            <td align="center" class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>

</asp:Content>

