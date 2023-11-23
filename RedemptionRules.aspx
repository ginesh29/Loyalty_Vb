<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="RedemptionRules.aspx.vb" Inherits="RedemptionRules" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        width: 79px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td>
                <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="Red" 
                    CssClass="centerAlign"></asp:Label>
                <br />
                <asp:Label ID="lblHeader" runat="server" Text="Redemption  Rules"></asp:Label>
                </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvRedRuleHead" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                    CellPadding="3" CellSpacing="1" Font-Names="Arial Narrow" Font-Size="Small" 
                    GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="<%# Container.dataitemindex+1 %>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ruleId" HeaderText="Rule Id" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RuleRes" HeaderText="Description" />
                    <asp:BoundField DataField="CustGrp" HeaderText="CustGrp">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CustGrpDes" HeaderText="Group" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FromPoints" HeaderText="Points">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Itemcd" HeaderText="Item Code" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ItemDes" HeaderText="Item Name" />
                    <asp:BoundField DataField="Cost" HeaderText="Cost" />
                    <asp:BoundField DataField="EntryBy" HeaderText="EntryBy" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="EntryDt">
                        <ItemTemplate>
                            <asp:Label ID="lblEntryDt" runat="server" 
                                Text='<%# Eval("EntryDt") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EditBy" HeaderText="EditBy" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="EditDt">
                        <ItemTemplate>
                            <asp:Label ID="lblEditDt" runat="server" 
                                Text='<%# Eval("EditDt") %>'></asp:Label>
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
        <td>
                <asp:Button ID="btnAddNew" runat="server" Text="New Redemption  Rule" 
                Width="175px" Height="28px" />

        </td>
    </tr>
    <tr>
        <td>
          
                    <asp:Panel ID="pnlRedRule" runat="server" BackColor="#EDF2F8" Visible="False" 
                        Width="604px">
                        <table>
                            <tr>
                                <td colspan="2">
                                    Redemption Rules Entry:
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style5">
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
                            <tr>
                                <td colspan="2">
                                   Rule Id:<asp:Label ID="lblRuleId" runat="server"></asp:Label></td>
                                <td>
                                    &nbsp;</td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                   
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Description
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDes" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="txtDes" ErrorMessage="*" Font-Bold="True" Font-Size="14pt" 
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="style5">
                                    Group
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCustGrp" runat="server" Width="135px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp; Points
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPoints" runat="server" Width="73px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ControlToValidate="txtPoints" ErrorMessage="*" Font-Bold="True" 
                                        Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Item Code</td>
                                <td>
                                    <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="txtItem" ErrorMessage="*" Font-Bold="True" Font-Size="14pt" 
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="style5">
                                    Item Name&nbsp; </td>
                                <td>
                                    <asp:TextBox ID="txtItemDes" runat="server" Enabled="False" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                    Cost</td>
                                <td>
                               
                                    <asp:TextBox ID="txtCost" runat="server" Width="73px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="44px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
              
        </td>
    </tr>
    <tr>
    <td>
    </td>
    </tr>
</table>
</asp:Content>

