<%@ Page Title="Add new user" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="RWAWebForms.AddNewUser" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () {
            showMasterLoginEmailButtons();
            markCurrentNavButton("lbAddUsers");
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Add new user" meta:resourcekey="lblTitleResource1"></asp:Label>
    </h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <asp:Panel runat="server" DefaultButton="btnAddNewUser">
        <div class="addPersonForm">
            <%--<div class="row">--%>
            <%-- PRVI STUPAC --%>
            <div class="col-sm-4">
                <%-- ime --%>
                <div class="form-group">
                    <asp:Label ID="lblFirstName" runat="server" Text="First name:" meta:resourcekey="lblFirstNameResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="First name is required" Display="Dynamic" Text="*" ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="rfvFirstNameResource1"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
                </div>
                <%-- prezime --%>
                <div class="form-group">
                    <asp:Label ID="lblLastName" runat="server" Text="Last name:" meta:resourcekey="lblLastNameResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" runat="server" ErrorMessage="Last name is required" Display="Dynamic" Text="*" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="rfvLastNameResource1"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                </div>
                <%-- emajl --%>
                <div class="form-group">
                    <asp:Label ID="lblEmail1" runat="server" Text="E-mail:" meta:resourcekey="lblEmail1Resource1"></asp:Label>
                    <asp:RegularExpressionValidator ID="regexEmail1" runat="server" ErrorMessage="Incorrect e-mail address format" Display="Dynamic" Text="*" ControlToValidate="txtEmail1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="regexEmail1Resource1"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvEmail1" runat="server" ControlToValidate="txtEmail1" ErrorMessage="E-mail address is required" Display="Dynamic" Text="*" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="rfvEmail1Resource1"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEmail1" CssClass="form-control" runat="server" meta:resourcekey="txtEmail1Resource1"></asp:TextBox>
                </div>
                <%-- neka logika za dodat JOŠ EMAJL ADRESA --%>
                <%-- prvi dodatni emajl --%>
                <div id="divEmail2" runat="server" visible="false" class="form-group">
                    <asp:RegularExpressionValidator ID="regexEmail2" runat="server" ErrorMessage="Incorrect e-mail address format" Display="Dynamic" Text="*" ControlToValidate="txtEmail2" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="regexEmail2Resource1"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtEmail2" CssClass="form-control" runat="server" meta:resourcekey="txtEmail2Resource1"></asp:TextBox>
                </div>
                <%-- drugi dodatni emajl --%>
                <div id="divEmail3" runat="server" visible="false" class="form-group">
                    <asp:RegularExpressionValidator ID="regexEmail3" runat="server" ErrorMessage="Incorrect e-mail address format" Display="Dynamic" Text="*" ControlToValidate="txtEmail3" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="regexEmail3Resource1"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtEmail3" CssClass="form-control" runat="server" meta:resourcekey="txtEmail3Resource1"></asp:TextBox>
                </div>
                <%-- gumbek za dodavat još emajl adresa --%>
                <asp:LinkButton ID="lbAddMoreEmailAddresses" OnClick="lbAddMoreEmailAddresses_Click" runat="server" meta:resourcekey="lbAddMoreEmailAddressesResource1">Add more email addresses ...</asp:LinkButton>
            </div>
            <%-- DRUGI STUPAC --%>
            <div class="col-sm-4">
                <%-- telefon --%>
                <div class="form-group">
                    <asp:Label ID="lblTelephone" runat="server" Text="Telephone:" meta:resourcekey="lblTelephoneResource1"></asp:Label>
                    <asp:TextBox ID="txtTelephone" CssClass="form-control" runat="server" meta:resourcekey="txtTelephoneResource1"></asp:TextBox>
                </div>
                <%-- grad --%>
                <div class="form-group">
                    <asp:Label ID="lblCity" runat="server" Text="City:" meta:resourcekey="lblCityResource1"></asp:Label>
                    <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server" meta:resourcekey="ddlCityResource1"></asp:DropDownList>
                </div>
                <%-- status --%>
                <div class="form-group">
                    <asp:Label ID="lblStatus" runat="server" Text="Status:" meta:resourcekey="lblStatusResource1"></asp:Label>
                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server" meta:resourcekey="ddlStatusResource1"></asp:DropDownList>
                </div>
            </div>
            <%-- TREĆI STUPAC --%>
            <div class="col-sm-4">
                <%-- lozinka --%>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" meta:resourcekey="lblPasswordResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" Display="Dynamic" Text="*" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="rfvPasswordResource1"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                </div>
                <%-- potvrda lozinke --%>
                <div class="form-group">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm password:" meta:resourcekey="lblConfirmPasswordResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="Password confirmation is required" Display="Dynamic" Text="*" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="rfvConfirmPasswordResource1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="Incorrect password confirmation" Display="Dynamic" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="CompareValidator1Resource1">*</asp:CompareValidator>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" runat="server" meta:resourcekey="txtConfirmPasswordResource1"></asp:TextBox>
                </div>
                <%-- gumbek --%>
                <div class="form-group">
                    <asp:Button ID="btnAddNewUser" OnClick="btnAddNewUser_Click" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="addUserValidationGroup" meta:resourcekey="btnAddNewUserResource1" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:ValidationSummary ID="addUserValidationSummary" runat="server" ForeColor="Red" ValidationGroup="addUserValidationGroup" meta:resourcekey="addUserValidationSummaryResource1" />
                </div>
            </div>
            <%--</div>--%>
        </div>
    </asp:Panel>
</asp:Content>
