<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RedVoucher.aspx.vb" Inherits="RedVoucher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    
        <table frame="box">
            <tr>
                <td align="center" colspan="6">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Label ID="lblCompany" runat="server" Font-Size="16pt" 
                        style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Voucher Number</td>
                <td>
                    <asp:Label ID="lblVoucherNo" runat="server"></asp:Label>
                </td>
                <td>
                    Accumulated Points</td>
                <td>
                    <asp:Label ID="lblAccPnts" runat="server"></asp:Label>
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
                    Redeemed Date</td>
                <td>
                    <asp:Label ID="lblRedDt" runat="server"></asp:Label>
                </td>
                <td>
                    Total Redeemed Points</td>
                <td>
                    <asp:Label ID="lblRedPnts" runat="server"></asp:Label>
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
                    Customer Code</td>
                <td>
                    <asp:Label ID="lblCustCd" runat="server"></asp:Label>
                </td>
                <td>
                    Current Redemption</td>
                <td>
                    <asp:Label ID="lblCurrentRed" runat="server"></asp:Label>
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
                    Name</td>
                <td>
                    <asp:Label ID="lblCustName" runat="server"></asp:Label>
                </td>
                <td>
                    Balance Points</td>
                <td>
                    <asp:Label ID="lblBalancePnts" runat="server"></asp:Label>
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
                    Remarks</td>
                <td colspan="5">
                    <asp:Label ID="lblNarration" runat="server" Width="400px"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    No.</td>
                <td align="center">
                    Item Code</td>
                <td align="center">
                    Item Name</td>
                <td align="center">
                    Qty</td>
                <td align="center">
                    Unit</td>
                <td align="center">
                    Points</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblSlNo" runat="server"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblItemcd" runat="server"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblItem" runat="server"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblQty" runat="server"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblUnit" runat="server"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblPoints" runat="server"></asp:Label>
                </td>
                <td align="center">
                    &nbsp;</td>
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
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Button" Visible="False" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
