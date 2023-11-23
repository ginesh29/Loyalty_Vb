<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="SalesRulesDownload.aspx.vb" Inherits="SalesRulesDownload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <span class="style2"><strong>Download --&gt;Sales Rules:</strong></span><br />
                <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="#990033"></asp:Label>

            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvSalesRuleHead" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="White" BorderStyle="Ridge" 
                    CellPadding="1" CellSpacing="1" Font-Names="Arial Narrow" Font-Size="Small" 
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text="<%# Container.dataitemindex+1 %>"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ruleId" HeaderText="ruleId" />
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDes" runat="server" Text='<%# Bind("des") %>' 
                                    CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cust.Group" HeaderText="Cust.Group" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="From Date">
                            <ItemTemplate>
                                <asp:Label ID="lblFromDt" runat="server" 
                                    Text='<%# Eval("FromDate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To.Date">
                            <ItemTemplate>
                                <asp:Label ID="lblToDt" runat="server" 
                                    Text='<%# Eval("ToDate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Points" HeaderText="Points">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiscPerc" HeaderText="Disc.Perc">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EntryBy"
                            HeaderText="EntryBy">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="EntryDt">
                            <ItemTemplate>
                                <asp:Label ID="lblEntryDt" runat="server" 
                                    Text='<%# Eval("EntryDt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EditBy" HeaderText="EditBy" />
                        <asp:TemplateField HeaderText="EditDt">
                            <ItemTemplate>
                                <asp:Label ID="lblEditDt" runat="server" 
                                    Text='<%# Eval("EditDt") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDownload" runat="server" CausesValidation="False" 
                                    CommandArgument='<%# Container.DataItemIndex %>' CommandName="Select" 
                                    Text="Download &amp; Update" onclick="lbDownload_Click"></asp:LinkButton>

                                <asp:ConfirmButtonExtender ID="CBEDownload" runat="server" ConfirmText="Do you want to Download & Update to your Local Server...?" TargetControlID="lbDownload">
                                </asp:ConfirmButtonExtender>
                                    
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CustGrp" HeaderText="CusrGrp" />
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHeader" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvSaleRuleDetail" runat="server" Font-Names="Arial Narrow" 
                    Font-Size="Small">
                </asp:GridView>
            </td>
            <td>
&nbsp;</td>
        </tr>
    </table>
</asp:Content>

