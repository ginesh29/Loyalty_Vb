<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="CustomerDetails.aspx.vb" Inherits="CustomerDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 24px;
        }
        .style4
        {
            height: 24px;
            width: 84px;
        }
        .style5
        {
            height: 13px;
        }
        .style6
        {
            width: 130px;
        }
        .style7
        {
            height: 13px;
            width: 130px;
        }
        .style8
        {
            height: 26px;
        }
        .style9
        {
            width: 130px;
            height: 26px;
        }
        .style10
        {
            width: 106px;
        }
        .style11
        {
            height: 26px;
            width: 106px;
        }
        .style12
        {
            height: 13px;
            width: 106px;
        }
        .style13
        {
            width: 118px;
        }
        .style14
        {
            height: 26px;
            width: 137px;
        }
        .style15
        {
            height: 13px;
            width: 137px;
        }
        .style16
        {
            width: 137px;
        }
        </style>
    <script type="text/javascript" language="javascript">
        function popupwindow() {
            var consumer = document.getElementById('ContentPlaceHolder1_txtConsumerNo').value;
            window.open('CustTrans.aspx?custId='+consumer+',null','toolbar=0,location=0,directories=0,status=1,scrollbars=1,resizable=1,width=830,height=350,left=40,top=50;help:no',true);
          
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>     
       <asp:Panel ID="pnlMain" runat="server" BorderColor="#99CCFF" 
                BorderStyle="Solid" BorderWidth="1px">
                <table>
                    <tr>
                        <td class="style124">
                            &nbsp;
                        </td>
                        <td colspan="6">
                            <asp:Label ID="lblPageHeader" runat="server" Font-Bold="True" 
                                Width="224px"></asp:Label>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            &nbsp;
                        </td>
                        <td colspan="1" class="style6">
                            &nbsp;
                        </td>
                        <td class="style13" colspan="5">
                            <asp:Label ID="lblMsg" runat="server" CssClass="centerAlign" Font-Italic="True" 
                                ForeColor="Red" Width="300px"></asp:Label>
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style124">
                            &nbsp;
                        </td>
                        <td class="style6">
                            <asp:Label ID="lblCustOrMobile" runat="server" Width="115px"></asp:Label>
                        </td>
                        <td class="style21" colspan="1" style="margin-left: 40px">
                            <asp:TextBox ID="txtConsumerNo" runat="server" AutoPostBack="True" 
                                Width="200px" MaxLength="20"></asp:TextBox>
                        </td>
                        <td class="style25" valign="middle">
                            <asp:ImageButton ID="imgBtnSearch" runat="server" CausesValidation="False" 
                                Height="21px" ImageUrl="~/Images/Search.png" Width="21px" />
                        </td>
                        <td valign="middle">
                        </td>
                        <td class="style16">
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                FilterType="Numbers" TargetControlID="txtConsumerNo">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style125">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Salutation
                        </td>
                        <td class="style71" colspan="1">
                            <asp:DropDownList ID="ddlSalutation" runat="server" TabIndex="1">
                                <asp:ListItem>Mr</asp:ListItem>
                                <asp:ListItem>Mrs</asp:ListItem>
                                <asp:ListItem>Miss</asp:ListItem>
                                <asp:ListItem>Dr</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style72">
                        </td>
                        <td>
                        </td>
                        <td class="style16">
                            <asp:Label ID="Label2" runat="server" Text="Currency" Visible="False"></asp:Label>
                        </td>
                        <td class="style75" colspan="2">
                            <asp:DropDownList ID="ddlCurr" runat="server" Height="16px" Visible="False" 
                                Width="86px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style126">
                            &nbsp;
                        </td>
                        <td class="style6">
                            First Name
                        </td>
                        <td class="style104" colspan="1">
                            <asp:TextBox ID="txtFName" runat="server" MaxLength="20" TabIndex="2" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td class="style105">
                        </td>
                        <td>
                        </td>
                        <td class="style16">
                            <asp:Label ID="Label1" runat="server" Text="Card Type" Visible="False"></asp:Label>
                        </td>
                        <td class="style63">
                            <asp:DropDownList ID="ddlCardType" runat="server" Height="16px" Visible="False" 
                                Width="86px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style9">
                            Last Name
                        </td>
                        <td class="style8" colspan="1">
                            <asp:TextBox ID="txtLName" runat="server" MaxLength="20" TabIndex="4" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td class="style8">
                        </td>
                        <td class="style8">
                        </td>
                        <td class="style14">
                            &nbsp;
                        </td>
                        <td class="style8">
                            <asp:TextBox ID="txtMName" runat="server" MaxLength="20" TabIndex="3" 
                                Visible="False" Width="160px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style127">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Gender
                        </td>
                        <td class="style21" valign="top">
                            <asp:RadioButton ID="rbMale" runat="server" Checked="True" GroupName="Gender" 
                                TabIndex="5" Text="Male" />
                            <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" 
                                Text="Female" />
                        </td>
                        <td class="style26">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style16">
                            &nbsp;
                        </td>
                        <td class="style10">
                            &nbsp;
                        </td>
                        <td class="style11">
                        </td>
                    </tr>
                    <tr>
                        <td class="style127">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Birth Date
                        </td>
                        <td class="style22" colspan="2">
                            <asp:DropDownList ID="ddlDay" runat="server" Width="66px" Font-Size="9.5pt">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="66px" Font-Size="9.5pt">
                                <asp:ListItem Value="0">Month</asp:ListItem>
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlYear" runat="server" Width="66px" Font-Size="9.5pt">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td class="style16">
                            &nbsp;
                        </td>
                        <td class="style11" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style127">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Address
                        </td>
                        <td class="style22" rowspan="2" valign="middle">
                            <asp:TextBox ID="txtAdd1" runat="server" MaxLength="20" TabIndex="7" 
                                TextMode="MultiLine" Width="200px"></asp:TextBox>
                        </td>
                        <td class="style26">
                            &nbsp;
                        </td>
                        <td>
                        </td>
                        <td class="style16">
                            &nbsp;</td>
                        <td class="style11" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">
                        </td>
                        <td class="style7">
                        </td>
                        <td class="style5">
                        </td>
                        <td class="style5">
                        </td>
                        <td class="style15">
                            <asp:Label ID="Label5" runat="server" Text="Earned Points"></asp:Label>
                        </td>
                        <td class="style5" colspan="2">
                            <asp:TextBox ID="txtAppr_points" runat="server" BackColor="Silver" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style127">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Mobile
                        </td>
                        <td class="style22" colspan="1">
                            <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" TabIndex="8" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td class="style26">
                        </td>
                        <td>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMobile" ValidChars="0123456789">
                            </asp:FilteredTextBoxExtender>
                            </td>
                        <td class="style16">
                            Redeemed Points
                        </td>
                        <td class="style11" colspan="2">
                            <asp:TextBox ID="txtRedmPoints" runat="server" BackColor="Silver" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style127">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Phone
                        </td>
                        <td class="style22" colspan="1">
                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" TabIndex="9" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td class="style26">
                            &nbsp;
                        </td>
                        <td>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPhone" ValidChars="0123456789">
                            </asp:FilteredTextBoxExtender>
                             </td>
                        <td class="style16">
                            Balance Points
                        </td>
                        <td class="style11" colspan="2">
                            <asp:TextBox ID="txtUnapprPoints" runat="server" BackColor="Silver" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style127">
                            &nbsp;
                        </td>
                        <td class="style6">
                            ID Card Number
                        </td>
                        <td class="style22" colspan="3">
                            <asp:TextBox ID="txtIdCardNo" runat="server" MaxLength="30" TabIndex="10" 
                                Width="200px"></asp:TextBox>
                            <asp:RadioButtonList ID="rblIdCardNo" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">Emirates ID</asp:ListItem>
                                <asp:ListItem>Labour Card</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="style16">
                            Last Purchase</td>
                        <td class="style11" colspan="2">
                            <asp:TextBox ID="txtLastPurDate" runat="server" BackColor="Silver" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style129">
                            &nbsp;</td>
                        <td class="style6">
                            Email
                        </td>
                        <td class="style110" colspan="1">
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" TabIndex="11" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td class="style111" colspan="2">
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ViewStateMode="Inherit"></asp:RegularExpressionValidator>
                            
                        </td>
                        <td class="style16">
                            Entry By</td>
                        <td class="style113">
                            <asp:TextBox ID="txtEntryBy" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="style114">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style129">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Nationality
                        </td>
                        <td class="style110" colspan="1">
                            <asp:DropDownList ID="ddlCountry" runat="server" TabIndex="12" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td class="style111">
                        </td>
                        <td>
                        </td>
                        <td class="style16">
                            Entry Date
                        </td>
                        <td class="style113">
                            <asp:TextBox ID="txtEntryDt" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="style114">
                        </td>
                    </tr>
                    <tr>
                        <td class="style130">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Group/Card Type
                        </td>
                        <td class="style93" colspan="1">
                            <asp:DropDownList ID="ddlCustGrp" runat="server" TabIndex="13" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td class="style94">
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style16">
                            Active
                        </td>
                        <td class="style93" colspan="2">
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style128">
                            &nbsp;
                        </td>
                        <td class="style6">
                            CustomerCompany
                        </td>
                        <td class="style52" colspan="1">
                            <asp:DropDownList ID="ddlCustCompany" runat="server" TabIndex="14" 
                                Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td class="style50">
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style16">
                            Card Issued
                        </td>
                        <td class="style52" colspan="2">
                            <asp:CheckBox ID="chkCardIssued" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style131">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Accommodation Area</td>
                        <td class="style35" colspan="2">
                            <asp:DropDownList ID="ddlAccArea" runat="server" TabIndex="15" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td class="style16">
                            <asp:Label ID="lblBlackList" runat="server" Text="Blacklisted"></asp:Label>
                        </td>
                        <td class="style34">
                            <asp:CheckBox ID="chkBlackList" runat="server" Width="150px" />
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style132">
                            &nbsp;
                        </td>
                        <td class="style6">
                            Religion
                        </td>
                        <td class="style98" colspan="1">
                            <asp:DropDownList ID="ddlReligion" runat="server" TabIndex="16" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td class="style99">
                            &nbsp;
                        </td>
                        <td>
                        </td>
                        <td class="style16">
                            Remarks
                        </td>
                        <td class="style102" colspan="2">
                            <asp:TextBox ID="txtRemarks" runat="server" Height="37px" TextMode="MultiLine" 
                                Width="175px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style131">
                            &nbsp;</td>
                        <td class="style6">
                            Profession</td>
                        <td class="style31" colspan="2">
                            <asp:DropDownList ID="ddlProfession" runat="server" TabIndex="16" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="style16">
                            &nbsp;</td>
                        <td class="style34">
                            &nbsp;</td>
                        <td class="style35">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style131">
                            &nbsp;
                        </td>
                        <td class="style6">
                            &nbsp;</td>
                        <td class="style31" colspan="2">
                            &nbsp;</td>
                        <td>
                        </td>
                        <td class="style16">
                            &nbsp;
                        </td>
                        <td class="style34">
                            &nbsp;
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style133">
                            &nbsp;
                        </td>
                        <td class="style6">
                            &nbsp;
                        </td>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" TabIndex="17" Text="Save" 
                                Width="73px" Height="28px" />
                        </td>
                        <td class="style82" colspan="4">
                            <asp:Button ID="btnTransDetails" runat="server" TabIndex="18" 
                                Text="Show Transaction Details" Visible="False" Width="170px" 
                                Height="28px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style133">
                            &nbsp;</td>
                        <td class="style6">
                            &nbsp;</td>
                        <td align="center">
                            &nbsp;</td>
                        <td class="style82" colspan="4">
                            &nbsp;</td>
                    </tr>
                </table>
                <asp:GridView ID="Gv_Customer" runat="server" AutoGenerateColumns="False" 
                    Visible="False">
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
            </asp:Panel>
      <br />
    
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </asp:Content>


