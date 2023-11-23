<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="SalesRules.aspx.vb" Inherits="SalesRules" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="Red" 
                    CssClass="centerAlign" Width="250px"></asp:Label>
                <br />
                <asp:Label ID="lblHeader" runat="server" Text="Settings --&gt; Sales Rules"></asp:Label>
                <br />
                <asp:GridView ID="gvSalesRuleHead" runat="server" AutoGenerateColumns="False" 
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
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To Date">
                            <ItemTemplate>
                                <asp:Label ID="lblToDt" runat="server" 
                                    Text='<%# Eval("ToDate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Points" HeaderText="Points">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiscPerc" HeaderText="Disc Perc">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EntryBy" HeaderText="EntryBy" />
                        <asp:TemplateField HeaderText="EntryDt">
                            <ItemTemplate>
                                <asp:Label ID="lblEntryDt" runat="server" 
                                    Text='<%# Eval("EntryDt") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="EditBy" HeaderText="EditBy" />
                        <asp:TemplateField HeaderText="EditDt">
                            <ItemTemplate>
                                <asp:Label ID="lblEditDt" runat="server" 
                                    Text='<%# Eval("EditDt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CustGrp" HeaderText="CusrGrp" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDownload" runat="server" CausesValidation="False" 
                                    CommandArgument="<%# Container.DataItemIndex %>" CommandName="Download" 
                                    Text="Download &amp; Update"></asp:LinkButton>
                                <asp:ConfirmButtonExtender ID="CBEDownload" runat="server" 
                                    ConfirmText="Do you want to Download &amp; Update to your Local Server...?" 
                                    TargetControlID="lbDownload">
                                </asp:ConfirmButtonExtender>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Select" Text="Add New Detail"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                                <asp:ConfirmButtonExtender ID="CBEDelete" TargetControlID="lnkDelete" ConfirmText="Delete..?" runat="server">
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

                <br />
                <asp:Button ID="btnAddNewSalesRule" runat="server" Text="New Sales Rule" 
                    Height="28px" Width="120px" />

                <br />

    <asp:Panel ID="pnlNewSRule" runat="server" Visible="false" Height="296px">
      <asp:Panel ID="pnlSalesRuleHead" runat="server" Visible="true" 
            BackColor="#EDF2F8" Width="604px">
        <table>
            <tr>
                <td colspan="2">
                    Sales Rules Header:
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
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
                    Rule Id:<asp:Label ID="lblRuleId" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtDes" ErrorMessage="*" Font-Bold="True" Font-Size="14pt" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    Cust Group
                </td>
                <td>
                    <asp:DropDownList ID="ddlCustGrp" runat="server" Width="115px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Points
                </td>
                <td>
                    <asp:TextBox ID="txtPoints" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtPoints" ErrorMessage="*" Font-Bold="True" 
                        Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Discount
                </td>
                <td>
                    <asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    From Date
                </td>
                <td>
                    <asp:TextBox ID="txtfromDt" runat="server" Width="113px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtfromDt" ErrorMessage="*" Font-Bold="True" 
                        Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    To Date
                </td>
                <td>
                    <asp:TextBox ID="txtToDt" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtToDt" ErrorMessage="*" Font-Bold="True" Font-Size="14pt" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
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
      </asp:Panel>
        <br />
        <table bgcolor="#EDF2F8">
            <tr>
                <td colspan="5">
                    Sales Rule Detail:
                </td>
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    Group
                </td>
                <td class="style6">
                    <asp:DropDownList ID="ddlGroups" runat="server" Width="140px">
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    
                </td>
                <td class="style6">
                    Sub Group
                </td>
                <td class="style6">
                    <asp:DropDownList ID="ddlSubGrp" runat="server" Width="170px">
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    Category
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtCategory" runat="server" Width="50px"></asp:TextBox>
                </td>
                <td class="style6">
                    Point</td>
                <td class="style6">
                    <asp:TextBox ID="txtPointDetail" runat="server" Width="50px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;Item</td>
                <td class="style6">
                    <asp:TextBox ID="txtItem" runat="server" Width="110px"></asp:TextBox>
                    <asp:Button ID="btnBrowse" runat="server" CausesValidation="False" Text="__" />
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Label ID="Label2" runat="server" Text="Item Des" Width="60px"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtItemDes" runat="server" ReadOnly="True" Width="168px"></asp:TextBox>
                </td>
                <td class="style6">
                    Discount</td>
                <td class="style6">
                    <asp:TextBox ID="txtDiscountDetail" runat="server" Width="50px"></asp:TextBox>
                </td>
                <td class="style6">
                    Value</td>
                <td class="style6">
                    <asp:TextBox ID="txtValue" runat="server" Width="50px"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtValue" ErrorMessage="*" Font-Bold="True" Font-Size="14pt" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style6">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="44px" />
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
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="center" colspan="2">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
        </table>

        <br />
    </asp:Panel>
                <asp:Label ID="lblHeaderDtl" runat="server" Font-Bold="True"></asp:Label>
    <br />
        <asp:GridView ID="gvSRDetail" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                    CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:BoundField DataField="RuleId" HeaderText="Rule Id" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Srl">
                    <ItemTemplate>
                        <asp:Label ID="lblSlNo" runat="server" Text='<%# Bind("srl") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="Grp" HeaderText="Grp" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="grpDes" HeaderText="Grp Des" />
                <asp:BoundField DataField="subGrp" HeaderText="Sub Grp" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="subGrpDes" HeaderText="Sub Grp Des" />
                <asp:BoundField DataField="Category" HeaderText="Category" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CategoryDes" HeaderText="Category Des" />
                <asp:BoundField DataField="ItemCd" HeaderText="Item Cd" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ItemDes" HeaderText="Item Des" />
                <asp:BoundField DataField="Amt" HeaderText="Amt" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DiscPerc" HeaderText="DiscPerc" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EntryBy" HeaderText="Entry By" />
                <asp:BoundField DataField="EntryDt" HeaderText="Entry Dt" />
                <asp:BoundField DataField="EditBy" HeaderText="Edit By" />
                <asp:BoundField DataField="EditDt" HeaderText="Edit Dt" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Delete"></asp:LinkButton>
                              <asp:ConfirmButtonExtender ID="CBEDelete" TargetControlID="lnkDelete" ConfirmText="Delete..?" runat="server">
                                </asp:ConfirmButtonExtender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CoCd" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblCoCd" runat="server" Text='<%# Bind("CoCd") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Srl" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblSrl" runat="server" Text='<%# Bind("srl") %>'></asp:Label>
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

     <asp:CalendarExtender ID="CE1" runat="server" TargetControlID="txtfromDt" Format="MMMM dd yyyy">
                </asp:CalendarExtender>
    <asp:CalendarExtender ID="CE2" runat="server" TargetControlID="txtToDt" Format="MMMM dd yyyy">
    </asp:CalendarExtender>
</asp:Content>

