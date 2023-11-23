<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="Redemption.aspx.vb" Inherits="Redemption" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 23px;
        }
        .style3
        {
            width: 339px;
        }
        .style4
        {
            text-decoration: underline;
        }
        .style6
        {
            width: 297px;
        }
        .style8
        {
            height: 28px;
        }
        .style9
        {
            height: 29px;
        }
        .style10
        {
            width: 297px;
            height: 29px;
        }
        .style11
        {
            width: 51px;
        }
        .style13
        {
            width: 104px;
        }
        .style14
        {
            height: 28px;
            width: 104px;
        }
        .style15
        {
            height: 23px;
            width: 104px;
        }
        .style17
        {
            height: 29px;
            width: 57px;
        }
        .style18
        {
            width: 7px;
        }
        .style19
        {
            height: 29px;
            width: 7px;
        }
        .style21
        {
        }
        .style22
        {
            width: 80px;
        }
        .style23
        {
            width: 182px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
 <table style="border: 1px solid #99CCFF;">
            <tr>
                <td valign="top" class="style3">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <strong>Redemption</strong>
                            </td>
                            <td class="style21" colspan="2">
                                <asp:Label ID="lblMsg" runat="server" Font-Italic="True" Width="190px" CssClass="centerAlign"></asp:Label>
                            </td>
                            <td class="style6">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                            </td>
                            <td class="style9">
                                <asp:Label ID="lblCustOrMobile" runat="server" Text="Cust No / Mobile No" Width="115px"></asp:Label>
                            </td>
                            <td class="style17">
                                <asp:TextBox ID="txtCostomerNo" runat="server" Width="170px" AutoPostBack="True"
                                    MaxLength="20"></asp:TextBox>
                            </td>
                            <td class="style19">
                                <asp:ImageButton ID="imgBtnSearch" runat="server" Height="21px" ImageUrl="~/Images/Search.png"
                                    Width="21px" EnableViewState="False" CausesValidation="False" />
                            </td>
                            <td class="style10">
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCostomerNo"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtCostomerNo" ErrorMessage="*" Font-Bold="True" 
                        Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="style21">
                            </td>
                            <td class="style18">
                                &nbsp;&nbsp;
                            </td>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3" valign="top">
                                <asp:Panel ID="pnlCustomers" runat="server" BorderColor="#99CCFF" BorderWidth="1px"
                                    BackColor="AliceBlue" Width="307px">
                                    <table>
                                        <tr>
                                            <td colspan="2" class="style4">
                                                Customer Details
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                Full Name:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Width="179px" Height="27px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                Address:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAddr1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style14">
                                                Card Issued By:
                                            </td>
                                            <td class="style8">
                                                <asp:Label ID="lblCompName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                Mobile:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                ID Card Number:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblIDCardNo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                Nationality:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNationality" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                Cust Group:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCustGrp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCustGrpCd" runat="server" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                Points Earned:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblApprPnts" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style15">
                                                <asp:Label ID="Label8" runat="server" Text="Redeemed Points:" Width="95px"></asp:Label>
                                            </td>
                                            <td class="style2">
                                                <asp:Label ID="lblRedmpnPnts" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                Balance Points:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUnApprPnts" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                <asp:Label ID="lblBlackList" runat="server" Text="BlackList" Width="75px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBlackListResult" runat="server" Width="75px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td valign="top" class="style6">
                                <asp:Panel ID="pnlRedeem" runat="server" Width="297px">
                                    <table>
                                        <tr>
                                            <td class="style4" colspan="2">
                                                Redemption Details
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                                <asp:Label ID="Label6" runat="server" Text="Units" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                                <asp:DropDownList ID="ddlUnits" runat="server" Visible="False">
                                                    <asp:ListItem>PCS</asp:ListItem>
                                                    <asp:ListItem>SET</asp:ListItem>
                                                    <asp:ListItem>PCK</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table class="style1" style="width: 116%">
                                                            <tr>
                                                                <td class="style22">
                                                                    <asp:Label ID="Label5" runat="server" Text="Base Qty" Visible="False"></asp:Label>
                                                                </td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtBaseQty" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22">
                                                                    <asp:Label ID="Label12" runat="server" Text="Quantity "></asp:Label>
                                                                </td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtQty" runat="server" Enabled="False" MaxLength="3" 
                                                                        Width="65px">1</asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="txtQty_FilteredTextBoxExtender" 
                                                                        runat="server" FilterType="Numbers" TargetControlID="txtQty">
                                                                    </asp:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                        ControlToValidate="txtQty" ErrorMessage="*" Font-Bold="True" Font-Size="14pt" 
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22">
                                                                    Voucher No</td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtVoucherNo" runat="server" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                        ControlToValidate="txtVoucherNo" ErrorMessage="*" Font-Bold="True" 
                                                                        Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22">
                                                                    Narration
                                                                </td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtNarration" runat="server" TextMode="MultiLine" 
                                                                        Width="182px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                                        ControlToValidate="txtNarration" ErrorMessage="*" Font-Bold="True" 
                                                                        Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22">
                                                                    Item&nbsp; Code
                                                                </td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtItemCode" runat="server" MaxLength="18" Width="100px" 
                                                                        ViewStateMode="Enabled"></asp:TextBox>
                                                                    <asp:Button ID="btnItemDetails" runat="server" CausesValidation="False" 
                                                                        Text="Get Details" Width="76px" />
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                                        ControlToValidate="txtItemCode" ErrorMessage="*" Font-Bold="True" 
                                                                        Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblMsgInvalidCust" runat="server" Font-Italic="True" 
                                                                        ForeColor="Red" Width="190px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22">
                                                                    Item Name
                                                                </td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtItemName" runat="server" Height="21px" Width="180px" 
                                                                        ReadOnly="True"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22">
                                                                    Cost</td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtCost" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22">
                                                                    <asp:Label ID="Label13" runat="server" Text="Redeem Points "></asp:Label>
                                                                </td>
                                                                <td class="style23">
                                                                    <asp:TextBox ID="txtRedeemPoints" runat="server" Enabled="False" 
                                                                        ReadOnly="True" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td class="style11">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btnSave" runat="server" Height="28px" 
                                                    Text="Redeem &amp; Print Voucher" Width="180px" />
                                                <asp:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Redeem...?" 
                                                    TargetControlID="btnSave">
                                                </asp:ConfirmButtonExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td class="style11">
                                                <asp:TextBox ID="txtRedeemDate" runat="server" Visible="False" Width="120px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="Doc Status " Visible="False"></asp:Label>
                                            </td>
                                            <td class="style11">
                                                <asp:DropDownList ID="ddlDocStatus" runat="server" Enabled="False" 
                                                    Visible="False">
                                                    <asp:ListItem Value="Post">Approve</asp:ListItem>
                                                    <asp:ListItem>Enter</asp:ListItem>
                                                    <asp:ListItem>Reverse</asp:ListItem>
                                                    <asp:ListItem>On Hold</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="Issue DocNo " Visible="False"></asp:Label>
                                            </td>
                                            <td class="style11">
                                                <asp:DropDownList ID="ddlDocType" runat="server" Enabled="False" 
                                                    Visible="False">
                                                    <asp:ListItem Value="SI01">Stk Issue-Redeem</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtIssueDocNo" runat="server" Enabled="False" Visible="False" 
                                                    Width="65px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td colspan="4" valign="top">
                                <asp:Panel ID="Panel1" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                Redemption History:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHisDetails" runat="server" Text="Details:" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:GridView ID="gvRedeemHistoryHd" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                                    Font-Names="Arial Narrow" Font-Size="9pt" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label7" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RedDt" HeaderText="Red Date" />
                                                        <asp:BoundField DataField="RedCompany" HeaderText="Red.Company">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RedPoints" HeaderText="Red.Points">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalPoints" HeaderText="Bal.Points">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="BalPoints" HeaderText="Bal.Points">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="narr" HeaderText="Narration" />
                                                        <asp:BoundField DataField="RefDocNo" HeaderText="RefDoc" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnDetails" runat="server" CausesValidation="False" 
                                                                    CommandArgument='<%# Bind("redNo") %>' Height="18px" 
                                                                    ImageUrl="~/Images/details.jpg" ToolTip="More Details" Width="16px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnPrnt" runat="server" CommandArgument='<%# Bind("redNo") %>'
                                                                    ImageUrl="~/Images/Print.png" CausesValidation="False" 
                                                                    ToolTip="Print Redemption Voucher" />
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
                                            <td valign="top">
                                                <asp:GridView ID="gvRedeemHistoryDetail" runat="server" AutoGenerateColumns="False"
                                                    BackColor="White" BorderColor="White" BorderStyle="Ridge" 
                                                    BorderWidth="2px" CellPadding="3"
                                                    CellSpacing="1" Font-Names="Arial Narrow" Font-Size="9pt" GridLines="None" 
                                                    Width="300px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.dataitemindex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ItemCode" HeaderText="Item Code">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ItemName" HeaderText="Item">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Qty" HeaderText="Qty">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Unit" HeaderText="Unit" Visible="False">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BaseQty" HeaderText="Base Qty" Visible="False">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Points" HeaderText="Points">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
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
                                            <td>
                                                <asp:Label ID="lblMsgNothing" runat="server" Font-Italic="True" ForeColor="Maroon"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
   
            <br />
                </asp:Content>


