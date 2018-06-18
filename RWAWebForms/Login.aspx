<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RWAWebForms.Login" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblNaslov" runat="server" Text="Login" meta:resourcekey="lblNaslovResource1"></asp:Label>
    </h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <div class="pageContent">
        <div class="row">
            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                <asp:Panel runat="server" DefaultButton="btnLogin">
                    <div class="loginForm">
                        <div class="form-group">
                            <%-- email --%>
                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:" meta:resourcekey="lblEmailResource1"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="E-mail address is required" Display="Dynamic" ControlToValidate="txtEmail" Text="*" ForeColor="Red" ValidationGroup="loginValidation" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid E-mail address" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*" Display="Dynamic" ForeColor="Red" ValidationGroup="loginValidation" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                        </div>
                        <%-- pswd --%>
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Password:" meta:resourcekey="lblPasswordResource1"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" Display="Dynamic" Text="*" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="loginValidation" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                        </div>
                        <%-- checkbox --%>
                        <div class="myCb">
                            <asp:CheckBox ID="cbRemeberMe" Text="Remeber me" CssClass="checkbox" runat="server" meta:resourcekey="cbRemeberMeResource1" />
                        </div>
                        <%-- buttonž --%>
                        <asp:Button ID="btnLogin" runat="server" Text="Enter" CssClass="btn btn-primary" OnClick="btnLogin_Click" ValidationGroup="loginValidation" meta:resourcekey="btnLoginResource1" />
                        <%-- validation summary i lbl greška --%>
                        <div class="validationSummary">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" meta:resourcekey="ValidationSummary1Resource1" />
                        </div>
                        <asp:Label ID="lblNoUser" runat="server" Text="Unknown user." Style="font-weight: normal;" ForeColor="Red" Visible="False" meta:resourcekey="lblNoUserResource1"></asp:Label>
                    </div>

                </asp:Panel>
            </div>
            <div class="col-sm-4"></div>
        </div>

    </div>
</asp:Content>
