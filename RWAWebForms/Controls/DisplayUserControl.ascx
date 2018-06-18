<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DisplayUserControl.ascx.cs" ClassName="DisplayUserControl" Inherits="RWAWebForms.Controls.DisplayUserControl" %>


<div class="personContainer">
    <table class="ucPersonTable" runat="server">
        <tbody>
            <%-- ime --%>
            <tr>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" Text="<%$ Resources:UcUserResources, lblFirstNameText %>"></asp:Label></td>
                <td>
                    <asp:TextBox CssClass="form-control input-sm" ID="txtFirstName" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFirstName" runat="server" Text="*" Display="Dynamic" ErrorMessage="First name is required" ValidationGroup="nonEmailValGroup" CssClass="ucValidators"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- prezime --%>
            <tr>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="<%$ Resources:UcUserResources, lblLastNameText %>"></asp:Label></td>
                <td>
                    <asp:TextBox CssClass="form-control input-sm" ID="txtLastName" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtLastName" runat="server" Text="*" Display="Dynamic" ErrorMessage="Last name is required" ValidationGroup="nonEmailValGroup" CssClass="ucValidators"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- odabir maila --%>
            <tr>
                <td></td>
                <td>
                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlEmail" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmail_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td>&nbsp;</td>
            </tr>
            <%-- uređivanje maila --%>
            <tr>
                <td>
                    <%--<asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label></td>--%>
                    <asp:Label ID="lblEmail" runat="server" Text="<%$ Resources:UcUserResources, lblEmailText %>"></asp:Label></td>
                <td>
                    <div class="input-group">
                        <asp:TextBox CssClass="form-control input-sm" ID="txtEmail" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton ValidationGroup="emailValGroup" CssClass="btn btn-sm btn-default" OnClick="btnEditEmail_Click" AutoPostBack="true" ID="btnEditEmail" runat="server">
                            <span class="glyphicon glyphicon-save"></span>
                            </asp:LinkButton>
                        </span>
                    </div>
                </td>
                <td>
                    <asp:RegularExpressionValidator CssClass="ucValidators" ControlToValidate="txtEmail" ID="RegularExpressionValidator1" Text="*" runat="server" ValidationGroup="emailValGroup" ErrorMessage="Incorrect E-mail format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" runat="server" Text="*" Display="Dynamic" ErrorMessage="Last name is required" ValidationGroup="emailValGroup" CssClass="ucValidators"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- telefon --%>
            <tr>
                <td>
                    <asp:Label ID="lblTelephone" runat="server" Text="<%$ Resources:UcUserResources, lblTelephoneText %>"></asp:Label></td>
                <td>
                    <asp:TextBox CssClass="form-control input-sm" ID="txtTelephone" runat="server"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
            <%-- password --%>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="<%$ Resources:UcUserResources, lblPasswordText %>"></asp:Label></td>
                <td>
                    <asp:TextBox CssClass="form-control input-sm" ID="txtPassword" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPassword" runat="server" Text="*" Display="Dynamic" ErrorMessage="Password is required" ValidationGroup="nonEmailValGroup" CssClass="ucValidators"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- status --%>
            <tr>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="<%$ Resources:UcUserResources, lblStatusText %>"></asp:Label></td>
                <td>
                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlStatus" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td>&nbsp;</td>
            </tr>
            <%-- grad --%>
            <tr>
                <td>
                    <asp:Label ID="lblCity" runat="server" Text="<%$ Resources:UcUserResources, lblCityText %>"></asp:Label></td>
                <td>
                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlCity" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td>&nbsp;</td>
            </tr>
            <%-- pucad --%>
            <tr>
                <td></td>
                <td>
                    <asp:Button CssClass="btn btn-sm btn-primary btnCtrl" ID="btnUpdate" runat="server" Text="<%$ Resources:UcUserResources, btnEditText %>" OnClick="btnUpdate_Click" ValidationGroup="nonEmailValGroup" />
                    <asp:Button CssClass="btn btn-sm btn-warning btnCtrl" ID="btnDelete" runat="server" Text="<%$ Resources:UcUserResources, btnDeleteText %>" OnClick="btnDelete_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <%-- validation summary --%>
            <tr>
                <td colspan="3">
                    <%--<asp:ValidationSummary ValidationGroup="nonEmailValGroup" ID="ValidationSummary1" runat="server" CssClass="ucValidators" Enabled="false" />--%>
                </td>
            </tr>
        </tbody>
    </table>
</div>

