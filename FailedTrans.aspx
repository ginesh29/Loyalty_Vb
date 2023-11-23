<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="FailedTrans.aspx.vb" Inherits="FailedTrans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            text-decoration: underline;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <table>
        <tr>
            <td class="style5" colspan="2">
                Loyalty--&gt;Failed Transactions</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                            <asp:Label ID="lblMsg" runat="server" CssClass="centerAlign" Font-Italic="True" 
                                ForeColor="Red" Width="300px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Customer No</td>
            <td>
                <asp:TextBox ID="txtCustNo" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtCustNo" ErrorMessage="*" Font-Bold="True" 
                                Font-Size="15pt" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
        </tr>
        <tr>
            <td valign="top">
                Transaction Date</td>
            <td style="color: #FF0000">
                <asp:TextBox ID="txtTrnDt" runat="server" Width="200px"></asp:TextBox>
                <br />
                Format: MM/dd/yyyy
            </td>
            <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtTrnDt" ErrorMessage="*" Font-Bold="True" 
                                Font-Size="15pt" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
        </tr>
        <tr>
            <td>
                Company</td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="txtCompany" ErrorMessage="*" Font-Bold="True" 
                                Font-Size="15pt" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
        </tr>
        <tr>
            <td>
                Counter No</td>
            <td>
                <asp:DropDownList ID="ddlCounterNo" runat="server" Width="200px" 
                    AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;</td>
            <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="ddlCounterNo" ErrorMessage="*" Font-Bold="True" 
                                Font-Size="15pt" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
        </tr>
        <tr>
            <td>
                Bill No</td>
            <td>
                <asp:TextBox ID="txtBillNo" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="txtBillNo" ErrorMessage="*" Font-Bold="True" 
                                Font-Size="15pt" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
        </tr>
        <tr>
            <td>
                Trans Location</td>
            <td>
                <asp:TextBox ID="txtTrnLoc" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtTrnLoc" ErrorMessage="*" Font-Bold="True" 
                                Font-Size="15pt" ForeColor="Red"></asp:RequiredFieldValidator>
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
        <tr>
            <td colspan="2">
                <asp:Button ID="btnLoad" runat="server" Text="Load Data from Selected POS Machine" 
                    Width="263px" Height="28px" />
            </td>
            <td>
                <asp:Button ID="btnApprove" runat="server" Text="Approve" Width="73px" 
                    Height="28px" Enabled="False" />
            </td>
        </tr>
        </table>
    &nbsp;<asp:GridView ID="gvFailedTrans" runat="server" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="White" 
        BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
        GridLines="None" ShowFooter="True" Width="766px">
        <Columns>
            <asp:BoundField DataField="TrnNo" HeaderText="TrnNo" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TrnSlNo" HeaderText="TrnSlNo" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TrnDt" HeaderText="Trans Date" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TrnDept" HeaderText="Trn Dept" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TrnPlu" HeaderText="Trn Plu" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="trnQty" HeaderText="Qty" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="trnPrice" HeaderText="Price" >
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="trnUnit" HeaderText="Unit" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="trnNetVal" HeaderText="Net Amount" >
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" Font-Bold="True" 
            HorizontalAlign="Right" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </asp:Content>

