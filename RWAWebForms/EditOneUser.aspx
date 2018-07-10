<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditOneUser.aspx.cs" Inherits="RWAWebForms.EditOneUser" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Controls/DisplayUserControl.ascx" TagPrefix="uc1" TagName="DisplayUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () {
            showMasterLoginEmailButtons();
        };
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Edit user" meta:resourcekey="lblTitleResource1"></asp:Label>
    </h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <div style="text-align:center">
        <asp:PlaceHolder ID="phCustomControle" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
