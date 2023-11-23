<%@ Page Title="" Language="VB" Debug="true" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="Reports.aspx.vb" Inherits="Reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 47px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border: 1px solid #99CCFF;">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Font-Italic="True" ForeColor="Maroon"></asp:Label>
            </td>
            <td>
                &nbsp; </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                         <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCustNo" runat="server" Text="Customer No/Mobile No" 
                                                    Width="155px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCustNo" runat="server" Height="19px" MaxLength="10" 
                                                    Width="155px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFrom" runat="server" Text="&nbsp;From"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDateFromCustTrans" runat="server" Width="100px"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtDateFromCustTrans_CalendarExtender" runat="server" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateFromCustTrans">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDateToCustTrans" runat="server" Height="20px" Width="100px"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtDateToCustTrans_CalendarExtender" runat="server" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateToCustTrans">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnShowReport" runat="server" Height="28px" Text="Show Report" 
                                                    Width="105px" />
                                            </td>
                                        </tr>
                                    </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Date From</td>
                                <td>
                                    <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Date To</td>
                                <td>
                                    <asp:TextBox ID="txtDateTo" runat="server" Height="20px" Width="125px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnShowReportRedemption" runat="server" Text="Show Report" 
                                        Width="105px" Height="28px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        TargetControlID="txtDateFrom" Format="dd/MM/yyyy"> </asp:CalendarExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" 
                                        TargetControlID="txtDateTo">
                                    </asp:CalendarExtender>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="rblRedRptOptions" runat="server">
                                                        <asp:ListItem Selected="True" Value="redCompWiseCustWise">Branch wise Redemption Report</asp:ListItem>
                                                        <asp:ListItem Value="redCompWiseSummary">Branch wise Redemption Summary Report</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="ViewSalesRules" runat="server">
                    
                        <table>
                            <tr>
                                <td>
                                    Sales Rules</td>
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
                                    <asp:RadioButtonList ID="rblSalesRules" runat="server" 
                                        RepeatDirection="Horizontal" Width="246px">
                                        <asp:ListItem Selected="True" Value="0"> From Local Server</asp:ListItem>
                                        <asp:ListItem Value="1"> From Main Server</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Button ID="btnShowSalesRules" runat="server" Height="28px" Text="Show" 
                                        Width="100px" />
                                </td>
                            </tr>
                        </table>
                    
                    </asp:View>
                    <asp:View ID="viewDailyTrans" runat="server">
                         <table>
                                        <tr>
                                            <td>
                                                Company</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCompany" runat="server" Enabled="False" Width="136px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="&nbsp;From"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDailyDt1" runat="server" Width="100px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateFromCustTrans">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="To"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDailyDt2" runat="server" Height="20px" Width="100px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateToCustTrans">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                    <asp:RadioButtonList ID="rdbSummaryDetail" runat="server" 
                                        RepeatDirection="Horizontal" Width="246px">
                                        <asp:ListItem Selected="True" Value="1"> Summary</asp:ListItem>
                                        <asp:ListItem Value="0"> Detail</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                            <td>
                                                <asp:Button ID="btnDailyTrans" runat="server" Height="28px" Text="Show Report" 
                                                    Width="105px" />
                                            </td>
                                        </tr>
                                    </table>
                    </asp:View>
                       <asp:View ID="viewInterBranch" runat="server">
                         <table>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="&nbsp;From"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDtInterBr" runat="server" Width="100px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateFromCustTrans">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="To"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtToDtInterBr" runat="server" Height="20px" Width="100px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateToCustTrans">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td align="center" class="style5">
                                                &nbsp;</td>
                                            <td align="center">
                                                Customer No:</td>
                                            <td>
                                                <asp:TextBox ID="txtCdInterBr" runat="server" Height="19px" MaxLength="10" 
                                                    Width="155px"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;<asp:Button ID="btnInterBranch" runat="server" Height="28px" 
                                                    Text="Show Report" Width="105px" />
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="979px" 
                    Height="469px">
                </rsweb:ReportViewer>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

