<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="UpdateSalesTransactions.aspx.vb" Inherits="UpdateSalesTransactions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .style7
    {
        text-decoration: underline;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="Maroon"></asp:Label>
    <asp:Panel ID="pnlMessage" runat="server" Height="129px" Width="385px" 
        BackColor="#99CCFF">
        <table>
            <tr>
                <td class="style7">
                    Update Sales Transactions:</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastUpdt" runat="server" Width="370px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Height="28px" 
                        Width="78px" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmText="Do you want to update the Sales transactions from Local Server ?" TargetControlID="btnUpdate" runat="server">
                    </asp:ConfirmButtonExtender>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

