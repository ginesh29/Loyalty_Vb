<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageLoyalty.master" AutoEventWireup="false" CodeFile="AccessDenied.aspx.vb" Inherits="AccessDenied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 100%;
            color: #FF0000;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="style5">
    
        <asp:Label ID="Label1" runat="server" CssClass="centerAlign" Font-Size="Medium" 
            Text="Access Denied..." Width="500px"></asp:Label>
    </div>
</asp:Content>

