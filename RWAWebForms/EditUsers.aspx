<%@ Page Title="Edit users" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="RWAWebForms.DisplayUsers" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Reference Control="~/Controls/DisplayUserControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () { showMasterLoginEmailButtons(); markCurrentNavButton("lbUpdateUsers"); };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Edit users" meta:resourcekey="lblTitleResource1"></asp:Label>
    </h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
        <asp:PlaceHolder ID="phCustomControle" runat="server"></asp:PlaceHolder>
</asp:Content>
