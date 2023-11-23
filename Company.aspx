<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="Company.aspx.vb" Inherits="Masters_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        text-decoration: underline;
    }
        .style6
        {
            height: 30px;
        }
        .style7
        {
            height: 29px;
        }
        .style8
        {
            height: 32px;
        }
        .style9
        {
            height: 35px;
        }
        .style10
        {
            height: 34px;
        }
        .style11
        {
            height: 33px;
        }
        .style12
        {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td class="style5">
            Company Details</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            Company Code</td>
        <td class="style6">
            <asp:Label ID="lblCompanyCode" runat="server"></asp:Label>
        </td>
        <td class="style6">
            </td>
    </tr>
    <tr>
        <td class="style7">
            Company Name</td>
        <td class="style7">
            <asp:TextBox ID="txtCompanyName" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style7">
            </td>
    </tr>
    <tr>
        <td class="style6">
            Address 1</td>
        <td class="style6">
            <asp:TextBox ID="txtAdd1" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style6">
            </td>
    </tr>
    <tr>
        <td class="style8">
            Address 2</td>
        <td class="style8">
            <asp:TextBox ID="txtAdd2" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style8">
            </td>
    </tr>
    <tr>
        <td class="style9">
            Address 3</td>
        <td class="style9">
            <asp:TextBox ID="txtAdd3" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style9">
            </td>
    </tr>
    <tr>
        <td class="style10">
            Phone </td>
        <td class="style10">
            <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style10">
            </td>
    </tr>
    <tr>
        <td class="style8">
            Fax</td>
        <td class="style8">
            <asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style8">
            </td>
    </tr>
    <tr>
        <td class="style11">
            E-Mail</td>
        <td class="style11">
            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style11">
            </td>
    </tr>
    <tr>
        <td class="style12">
            Server Name</td>
        <td class="style12">
            <asp:TextBox ID="txtServerName" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style12">
            </td>
    </tr>
    <tr>
        <td class="style12">
            Database Name</td>
        <td class="style12">
            <asp:TextBox ID="txtDbName" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style12">
            </td>
    </tr>
    <tr>
        <td class="style12">
            DB
            Username</td>
        <td class="style12">
            <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td class="style12">
            </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

