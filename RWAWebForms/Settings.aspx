<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="RWAWebForms.Settings" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () {
            showMasterLoginEmailButtons();
            markCurrentNavButton("lbSettings");
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Settings" meta:resourcekey="lblTitleResource1"></asp:Label>
    </h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <div class="pageContent">
        <div class="row">
            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                <%-- TEMA --%>
                <div class="form-group">
                    <asp:Label ID="lblTheme" runat="server" Text="Theme:" meta:resourcekey="lblThemeResource1"></asp:Label>
                    <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged" meta:resourcekey="ddlThemeResource1">
                        <asp:ListItem Text="--- choose ---" Value="0" meta:resourcekey="ListItemResource1" />
                        <asp:ListItem Text="Default" Value="Default" meta:resourcekey="ListItemResource2" />
                        <asp:ListItem Text="Blue" Value="Blue" meta:resourcekey="ListItemResource3" />
                        <asp:ListItem Text="Red" Value="Red" meta:resourcekey="ListItemResource4" />
                    </asp:DropDownList>
                </div>
                <%-- JEZIK --%>
                <div class="form-group">
                    <asp:Label ID="lblLanguage" runat="server" Text="Language:" meta:resourcekey="lblLanguageResource1"></asp:Label>
                    <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" meta:resourcekey="ddlLanguageResource1">
                        <asp:ListItem Text="--- choose ---" Value="0" meta:resourcekey="ListItemResource5" />
                        <asp:ListItem Text="Croatian" Value="hr" meta:resourcekey="ListItemResource6" />
                        <asp:ListItem Text="English" Value="en" meta:resourcekey="ListItemResource7" />
                    </asp:DropDownList>
                </div>
                <%-- REPO --%>
                <div class="form-group">
                    <asp:Label ID="lblRepository" runat="server" Text="Repository:" meta:resourcekey="lblRepositoryResource1"></asp:Label>
                    <asp:DropDownList ID="ddlRepository" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRepository_SelectedIndexChanged" CssClass="form-control" meta:resourcekey="ddlRepositoryResource1">
                        <asp:ListItem Text="--- choose ---" Value="0" meta:resourcekey="ListItemResource8" />
                        <asp:ListItem Text="Text file" Value="1" meta:resourcekey="ListItemResource9" />
                        <asp:ListItem Text="DataBase" Value="2" meta:resourcekey="ListItemResource10" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4"></div>
        </div>

    </div>
</asp:Content>
