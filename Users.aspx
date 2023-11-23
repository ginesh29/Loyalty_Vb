<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Masters_Users" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        text-decoration: underline;
    }
        .style6
        {
            text-decoration: underline;
            height: 24px;
            width: 101px;
        }
        .style7
        {
            height: 24px;
        }
        .style8
        {
        }
        .style9
        {
        }
        .style10
        {
            text-decoration: underline;
            width: 101px;
        }
        .style11
        {
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td class="style6">
            User Details</td>
        <td colspan="2" class="style7">
            <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="Red" 
                CssClass="centerAlign" Font-Size="12pt" Width="270px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style10">
            </td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="gvUserList" runat="server" BackColor="White" 
                BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                CellSpacing="1" GridLines="None" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="No">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Company" HeaderText="Company" />
                    <asp:TemplateField HeaderText="Expiry Date">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" 
                                Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("ExpiryDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EntryBy" HeaderText="Entry By" />
                    <asp:TemplateField HeaderText="Entry Date">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" 
                                Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("EntryDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UserType" HeaderText="User Type" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" 
                                CommandName="Delete" Text="Delete"></asp:LinkButton>
                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="lnkDelete" ConfirmText="Delete...?" runat="server">
                            </asp:ConfirmButtonExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="cd" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblCd" runat="server" Text='<%# Bind("cd") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style10">
            </td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" colspan="3">
            New User Creation</td>
    </tr>
    <tr>
        <td class="style11">
            Company</td>
        <td class="style9" colspan="2">
            <asp:DropDownList ID="ddlCompany" runat="server" Width="175px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style11">
            &nbsp;</td>
        <td class="style8" colspan="2">
            <asp:RadioButtonList ID="rbUserType" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">Normal User</asp:ListItem>
                <asp:ListItem Value="2">Admin User</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style11">
            User Name</td>
        <td class="style9">
            <asp:TextBox ID="txtUsername" runat="server" MaxLength="20" Width="125px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtUsername" ErrorMessage="*" Font-Bold="True" 
                Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style11">
            Password</td>
        <td class="style9">
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="125px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPwd" ErrorMessage="*" Font-Bold="True" 
                Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style11">
            Confirm password</td>
        <td class="style9">
            <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" 
                Width="125px"></asp:TextBox>
        </td>
        <td>   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtConfirmPwd" ErrorMessage="*" Font-Bold="True" 
                Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtPwd" ControlToValidate="txtConfirmPwd" 
                ErrorMessage="Password  mismatch..." ForeColor="Red" Width="200px"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style11">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style11">
            &nbsp;</td>
        <td class="style9">
            <asp:Button ID="btnCreateUser" runat="server" Text="Create User" Height="28px" 
                Width="100px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

