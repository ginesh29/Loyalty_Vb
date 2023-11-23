<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="GeneralSettings.aspx.vb" Inherits="GeneralSettings" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 191px;
        }
        .style7
    {
        width: 631px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
     <table>
        <tr>
            <td class="style7">
                <asp:Label ID="lblMsg" runat="server" CssClass="centerAlign" Font-Italic="True" 
                    ForeColor="Red" Width="356px"></asp:Label>
                <br />
                
            </td>
        </tr>
         <tr>
             <td class="style7">
                 <AjaxControlToolkit:Accordion ID="Accordion2" runat="server" 
                     ContentCssClass="accordionContent" CssClass="accordion" 
                     HeaderCssClass="accordionHeader" 
                     HeaderSelectedCssClass="accordionHeaderSelected" Height="557px" 
                     Width="685px">
                     <panes>
                         <AjaxControlToolkit:AccordionPane ID="AccordionPane9" runat="server" 
                             ContentCssClass="" HeaderCssClass="">
                             <header>
                                 Change Password</header>
                             <content>
                                 <asp:Panel ID="pnlChangePwd" runat="server">
                    <table>
                           <tr>
                            <td>
                                Username
                            </td>
                            <td>
                                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                            </td>
                            <td class="style6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtUser" ErrorMessage="*" Font-Bold="True" Font-Size="14pt" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Current Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="style6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtOldPwd" ErrorMessage="*" Font-Bold="True" 
                                    Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                New Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="style6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtNewPwd" ErrorMessage="*" Font-Bold="True" 
                                    Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Confirm Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="style6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtConfirm" ErrorMessage="*" Font-Bold="True" 
                                    Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToCompare="txtNewPwd" ControlToValidate="txtConfirm" 
                                    ErrorMessage="Password  mismatch..." ForeColor="Red"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td class="style6">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnChangePwd" runat="server" Text="Change Password" Height="28"
                                    Width="123px" />
                            </td>
                            <td class="style6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                             </content>
                         </AjaxControlToolkit:AccordionPane>
                         <AjaxControlToolkit:AccordionPane ID="AccordionPane10" runat="server" 
                             ContentCssClass="" HeaderCssClass="">
                             <header>
                                 Sales Updation</header>
                             <content>
                                <table>
                     <tr>
                         <td>
                             Sales Updating Interval(in Minutes)</td>
                         <td>
                             <asp:DropDownList ID="ddlTimeInterval0" runat="server" Height="21px" 
                                 Width="57px">
                                 <asp:ListItem>10</asp:ListItem>
                                 <asp:ListItem>20</asp:ListItem>
                                 <asp:ListItem>30</asp:ListItem>
                                 <asp:ListItem>40</asp:ListItem>
                                 <asp:ListItem>50</asp:ListItem>
                                 <asp:ListItem>60</asp:ListItem>
                                 <asp:ListItem>70</asp:ListItem>
                                 <asp:ListItem>80</asp:ListItem>
                                 <asp:ListItem>90</asp:ListItem>
                                 <asp:ListItem>100</asp:ListItem>
                                 <asp:ListItem>110</asp:ListItem>
                                 <asp:ListItem>120</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                         <td>
                             <asp:Button ID="btnSaveInterval0" runat="server" CausesValidation="False"  Height="28" 
                                 Text="Save Changes" Width="106px" />
                                <AjaxControlToolkit:ConfirmButtonExtender ID="CBEInterval" runat="server" ConfirmText="Update...?" TargetControlID="btnSaveInterval0">
                             </AjaxControlToolkit:ConfirmButtonExtender>
                         </td>
                     </tr>
                 </table>
                             </content>
                         </AjaxControlToolkit:AccordionPane>
                          <AjaxControlToolkit:AccordionPane ID="AccordionPane1" runat="server" 
                             ContentCssClass="" HeaderCssClass="">
                             <header>
                                Master Table Updation : Ly_Groups</header>
                             <content>
                                 <asp:Button ID="btnUpdateLy_Groups" runat="server" Height="28" Width="180"
                     Text="Update Master Ly_Groups" CausesValidation="False" />
                                 <asp:Label ID="Label1" runat="server" Text="NB: Update from Raha Mall Database(Prosmart) to Loyalty Main Database"></asp:Label>
                       <AjaxControlToolkit:ConfirmButtonExtender ID="CBEGroups" runat="server" ConfirmText="Update...?" TargetControlID="btnUpdateLy_Groups">
                             </AjaxControlToolkit:ConfirmButtonExtender>
                             </content>
                         </AjaxControlToolkit:AccordionPane>
                     </panes>
                 </AjaxControlToolkit:Accordion>
             </td>
         </tr>
         <tr>
             <td class="style7">
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style7">
                 <asp:CheckBox ID="cbReligion" runat="server" Checked="True" Visible="False" />
             </td>
         </tr>
         <tr>
             <td class="style7">
                
             </td>
         </tr>
         <tr>
             <td class="style7">
                </td>
         </tr>
    </table>
    </asp:Panel>
</asp:Content>

