<%@ Page Title="Error" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CustomErrorPage.aspx.cs" Inherits="RWAWebForms.CustomErrorPage" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblMainTitle" runat="server" Text="Error Page" meta:resourcekey="lblMainTitleResource1"></asp:Label>
    </h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <h3 style="color:red">
        <asp:Label runat="server" ID="lblErrorTitle" Text="An error has occured" meta:resourcekey="lblErrorTitleResource1"></asp:Label>
    </h3>
    <div>
        <asp:Label runat="server" ID="lblDetailsTitle" Text="Error details:" meta:resourcekey="lblDetailsTitleResource1"></asp:Label>
        <asp:Label CssClass="text-danger" runat="server" ID="lblErrorDetails" meta:resourcekey="lblErrorDetailsResource1"></asp:Label>
    </div>
</asp:Content>
