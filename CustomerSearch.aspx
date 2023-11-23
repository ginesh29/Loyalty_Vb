<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CustomerSearch.aspx.vb" Inherits="CustomerSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript">
        function windowclose() {
            window.close();
            // window.location.href="frmReceipt.aspxname=we";   
            opener.location.reload("CustomerDetails.aspx");
        }
        
        function windowcloseOpenRedeem() {
            window.close();
            // window.location.href="frmReceipt.aspxname=we";   
            opener.location.reload("Redemption.aspx");
        }
        function windowcloseOpenReports() {
            window.close();
            // window.location.href="frmReceipt.aspxname=we";   
            opener.location.reload("Reports.aspx");
        }
        
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    
        <table>
            <tr>
                <td>
                    Type Mobile No / Name:</td>
                <td>
                    <asp:TextBox ID="txtKeyword" runat="server" AutoPostBack="True" Width="319px" 
                        MaxLength="20"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="imgBtnSearch" runat="server" 
                        ImageUrl="~/Images/search.gif" />
                </td>
            </tr>
            </table>
    <asp:GridView ID="gvCustomers" runat="server" CellPadding="3" GridLines="None" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="White" 
            BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" Font-Names="Arial Narrow" 
            Font-Size="Small">
            <Columns>
                <asp:TemplateField HeaderText="SlNo">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer No">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbCd" runat="server" CommandArgument='<%# Bind("cd") %>' 
                            Text='<%# Bind("cd") %>' Width="100%"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FNAme" HeaderText="First Name" />
                <asp:BoundField DataField="MName" HeaderText="Middle Name" />
                <asp:BoundField DataField="LName" HeaderText="Last Name" />
                <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                <asp:BoundField DataField="Addr1" HeaderText="Address " />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                <asp:BoundField DataField="custgrp" HeaderText="Customer Group" />
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
        <br />
        <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="Maroon"></asp:Label>
    </div>
    </form>
</body>
</html>
