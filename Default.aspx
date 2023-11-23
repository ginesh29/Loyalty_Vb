<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/pluralism/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 284px;
        }
        .style3
        {
            width: 593px;
        }
    
a {
	color: #FF5A00;
}

* {
	padding: 0;
    margin-left: 0;
    margin-right: 0;
    margin-top: 0;
}

        .style4
        {
            height: 118px;
        }
        .style5
        {
            width: 284px;
            height: 118px;
        }
        .style6
        {
            width: 593px;
            height: 118px;
        }
        .style7
        {
            height: 118px;
            width: 574px;
        }
        .style8
        {
            width: 574px;
        }
        .best{font-family:HeliosExt;font-weight:bold;font-size:10px;color:#505050;padding-top:60px;padding-right:40px;}
        
        .style9
        {
            width: 59px;
        }
        
        .style10
        {
            height: 33px;
        }
        .style11
        {
            width: 59px;
            height: 33px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
    
        <table class="style1">
            <tr>
                <td class="style7">
                    </td>
                <td class="style5">
                    </td>
                <td class="style6">
                    </td>
                <td class="style4">
                    </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style2">
	<table cellpadding="0" cellspacing="0" border="0" height="100%">
		<tr>
			<td><img src="App_Themes/32/images/cap03.jpg"></td>
		</tr>
		<tr>
			<td width="496" height="217" 
                background="App_Themes/32/images/bg03.jpg" valign="top" 
                style="padding-left:20px;">
			<img src="App_Themes/32/images/best.jpg" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <table>
                            <tr>
                                <td class="style14">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                <td class="style14" align="center" colspan="2">
                                    &nbsp;CUSTOMER LOYALTY SYSTEM</td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    &nbsp;</td>
                                <td class="style9">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    </td>
                                <td class="style11">
                                    Username&nbsp; </td>
                                <td class="style10">
                                    <asp:TextBox ID="txtUsername" runat="server" Width="150px" MaxLength="20" 
                                        Height="21px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    </td>
                                <td class="style11">
                                    Password</td>
                                <td class="style10">
                                    <asp:TextBox ID="txtPwd" runat="server" Width="150px" 
                                        Height="21px" TextMode="Password">123</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    </td>
                                <td class="style11">
                                    </td>
                                <td class="style10">
                                    <asp:Button ID="btnLogin" runat="server" Height="27px" Text="Login" 
                                        Width="50px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    &nbsp;</td>
                                <td class="style9">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblLogin" runat="server" Font-Italic="True" ForeColor="#990033"></asp:Label>
                                </td>
                            </tr>
                        </table>
			</td>	
		</tr>
		<tr>
			<td height="100%" valign="bottom" align="center" style="padding-bottom:15px;">&nbsp;</td>
		</tr>
		<tr>
			<td height="100%" valign="bottom" align="center" style="padding-bottom:15px;"><div class="best" style="font-size:9px;">
                Copyright © 2014. All rights reserved. Designed & Developed By Luminosoft Technologies.</div></td>
		</tr>

	</table>
	            </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
       
    
    </div>
    </form>
</body>
</html>
