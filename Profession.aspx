<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="Profession.aspx.vb" Inherits="Profession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td colspan="4">
           Settings-->Profession</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="4">
                            <asp:Label ID="lblMsg" runat="server" CssClass="centerAlign" Font-Italic="True" 
                                ForeColor="Red" Width="300px"></asp:Label>
        </td>
        <td>
                            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="5">
            <asp:GridView ID="gvProfession" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                CellPadding="3" CellSpacing="1" GridLines="None" Width="575px">
                <Columns>
                    <asp:TemplateField HeaderText="No">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProfessionId" HeaderText="Profession Id">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Profession" HeaderText="Profession">
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="False" 
                                CommandArgument="<%# Container.DataItemIndex %>" Height="22px" 
                                ImageUrl="~/Images/edit2.jpg"/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" runat="server" 
                                CommandArgument='<%# Container.DataItemIndex %>' Height="22px" 
                                ImageUrl="~/Images/delete.png"  
                                CausesValidation="False" />
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
        <td colspan="2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:TextBox ID="txtprofessionId" runat="server" Width="200px" Visible="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            New Profession</td>
        <td>
            <asp:TextBox ID="txtprofession" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtprofession" ErrorMessage="*" 
                Font-Bold="True" Font-Size="15pt" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Button ID="btnSaveProfession" runat="server" Text="Save" Height="30px" 
                Width="120px" CssClass="btnStyle1" />
        </td>
        <td>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="30px" 
                Width="125px" CausesValidation="False" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

