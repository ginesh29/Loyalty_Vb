<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CustTrans.aspx.vb" Inherits="CustTrans" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


* {
	padding: 0;
    margin-left: 0px;
    margin-right: 0;
    margin-top: 0;
    margin-bottom: 0px;
}

        .style1
        {
        }
        .style3
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table>
            <tr>
                <td class="style1" colspan="5">
     
       
    <asp:Label ID="lblTrDtHead" runat="server" Text=" Transaction Details" Font-Bold="True" 
                        ForeColor="Maroon"></asp:Label>
       
<%--   <script language="javascript">
        function findAdmin(ID)
         {
            if (ID == 1)
             {
                var key = event.keyCode;
                if (key == 13) 
                {
                    var strAdmin = document.form1.txtConsumerNo.value;
                    var intIndexOfMatch = strAdmin.indexOf("'");
                    while (intIndexOfMatch != -1)
                     {
                        strAdmin = strAdmin.replace("'", "~")
                        intIndexOfMatch = strAdmin.indexOf("'");
                     }
                    window.open("CustomerSearch.aspx?", "myWindow", "height=350, width=500, scrollbars=yes");
                }
            }
//            else 
//            {
//                var strAdmin = document.form1.txtFirstName.value;
//                var intIndexOfMatch = strAdmin.indexOf("'");
//                while (intIndexOfMatch != -1)
//                 {
//                    strAdmin = strAdmin.replace("'", "~")
//                    intIndexOfMatch = strAdmin.indexOf("'");
//                }
//                //  window.open("../system/FindAdmin.aspx?var1=1&searchSTR=" + strAdmin + "", "myWindow", "height=350, width=500, scrollbars=yes");
//            }
        }

    </script>--%>&nbsp;&nbsp;</td>
                <td class="style1">
     
       
                    &nbsp;</td>
                <td class="style1">
     
       
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" align="left" colspan="3">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
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
                <td class="style3" align="left">
                    Customer No</td>
                <td>
                    <asp:TextBox ID="txtId" runat="server" ReadOnly="True" MaxLength="20"></asp:TextBox>
                    </td>
                <td>
                    From</td>
                <td>
                    <asp:TextBox ID="txtFrom" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    To</td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server" Width="100px"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show" Width="100px" />
                </td>
            </tr>
            <tr>
                <td class="style3" align="left">
                    Customer Name</td>
                <td colspan="6">
                    <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="380px"></asp:TextBox>
                </td>
            </tr>
            </table>
                        <asp:GridView ID="gvCustTrans" runat="server" 
        AutoGenerateColumns="False" Font-Names="Arial Narrow"
                            Font-Size="Small" BackColor="White" BorderColor="White" 
            BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
            GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="No">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text="<%# Container.dataitemindex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trans Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("TrnDt")) %>'
                                            Width="60px"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CompName" HeaderText="Company" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle Width="140px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PosId" HeaderText="Pos Id">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BillNo" HeaderText="Bill No">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RuleId" HeaderText="Rule Id">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="itemcd" HeaderText="Item Code">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemName" HeaderText="Item Name">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="qty" HeaderText="Qty">
                                    <HeaderStyle HorizontalAlign="Center" />

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SellPr" HeaderText="SellPr">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CostPr" HeaderText="CostPr">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Amt" HeaderText="Amont">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Points" HeaderText="Points">
                                    <HeaderStyle HorizontalAlign="Center" />
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
                           <br />
                        <asp:Label ID="lblNothing" runat="server" Font-Italic="True" 
                            ForeColor="#3333FF"></asp:Label>
                        </div>
    </form>
</body>
</html>
