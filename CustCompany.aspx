<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="CustCompany.aspx.vb" Inherits="CustCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
        }
        .style6
        {
            width: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
            <td class="style5" colspan="5">
               Settings-->Customer Company</td>
        </tr>
    <tr>
            <td class="style5" colspan="5">
                            <asp:Label ID="lblMsg" runat="server" CssClass="centerAlign" Font-Italic="True" 
                                ForeColor="Red" Width="300px"></asp:Label>
            </td>
        </tr>
    <tr>
            <td class="style5" colspan="5">
    <asp:GridView ID="gvCustCompany" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                CellPadding="3" CellSpacing="1" GridLines="None" Width="678px" 
                    AllowPaging="True">
        <Columns>
            <asp:TemplateField HeaderText="No">
                <ItemTemplate>
                    <asp:Label ID="lblProfessionId" runat="server" 
                                Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="CustCoId" HeaderText="Company Id">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="custCo" HeaderText="Company Name">
            <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Addr" HeaderText="Address">
            <ItemStyle Width="250px" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="False" 
                        CommandArgument="<%# Container.DataItemIndex %>" Height="22px" 
                        ImageUrl="~/Images/edit2.jpg" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="imgDelete" runat="server" 
                                CommandArgument='<%# Container.DataItemIndex %>' Height="22px" 
                                ImageUrl="~/Images/delete.png" 
                        Width="27px" CausesValidation="False" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
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
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
            <asp:TextBox ID="txtCustCompId" runat="server" Width="195px" Visible="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                New Company</td>
            <td class="style6">
            <asp:TextBox ID="txtCustComp" runat="server" Width="280px"></asp:TextBox>
            </td>
            <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtCustComp" ErrorMessage="*" 
                Font-Bold="True" Font-Size="15pt" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                Address</td>
            <td class="style6">
            <asp:TextBox ID="txtCompAddr" runat="server" Width="280px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
            <asp:Button ID="btnSaveCustCompany" runat="server" Text="Save" Height="30px" 
                Width="125px" />
            </td>
            <td>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="30px" 
                Width="125px" CausesValidation="False" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

