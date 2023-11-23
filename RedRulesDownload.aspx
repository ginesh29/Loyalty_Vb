<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="RedRulesDownload.aspx.vb" Inherits="RedRulesDownload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td>
                <span class="style2" style="width: 261px"><strong>Download --&gt;Redemption Rules:</strong></span></td>
    </tr>
    <tr>
        <td>
                <asp:Label ID="lblMsg" runat="server" Font-Italic="True" 
                ForeColor="#990033" CssClass="centerAlign"></asp:Label>

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
                    <asp:BoundField DataField="ruleId" HeaderText="Rule Id" />
                    <asp:BoundField DataField="RuleRes" HeaderText="Description" />
                    <asp:BoundField DataField="CustGrp" HeaderText="CustGrp">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CustGrpDes" HeaderText="Cus .Group" />
                    <asp:BoundField DataField="FromPoints" HeaderText="From Points">
                    </asp:BoundField>
                    <asp:BoundField DataField="Itemcd" HeaderText="Item Code" />
                    <asp:BoundField DataField="ItemDes" HeaderText="Item" />
                    <asp:BoundField DataField="EntryBy" HeaderText="EntryBy" />
                    <asp:BoundField DataField="EntryDt" HeaderText="EntryDt" />
                    <asp:BoundField DataField="EditBy" HeaderText="EditBy" />
                    <asp:BoundField DataField="EditDt" HeaderText="EditDt" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDownload" runat="server" 
                                CommandArgument="<%# Container.dataitemindex+1 %>" 
                                onclick="lnkDownload_Click">Download &amp; Update</asp:LinkButton>
                            <asp:ConfirmButtonExtender ID="CBEDownload" runat="server" ConfirmText="Do you want to Download & Update to your Local Server...?" TargetControlID="lnkDownload">
                            </asp:ConfirmButtonExtender>
                                
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
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

