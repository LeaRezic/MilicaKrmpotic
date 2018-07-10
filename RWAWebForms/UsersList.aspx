<%@ Page Title="User list" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="RWAWebForms.UsersList" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%--EnableEventValidation="false"--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/myScript.js"></script>
    <script>

        function nonAdminYouShallNotPass() {
            var adminOnlyButtons = document.getElementsByClassName("adminOnly");
            for (var i = 0; i < adminOnlyButtons.length; i++) {
                adminOnlyButtons[i].onclick = function (e) {
                    e.preventDefault();
                    toastr.warning("Za pristup stranici morate imati prava administratora.");
                    document.getElementById("lbDisplayUsers").focus();
                }
            }
        }

        window.onload = function () {
            showMasterLoginEmailButtons();
            markCurrentNavButton("lbDisplayUsers");

        };
    </script>
</asp:Content>

<%-- TITLE --%>
<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Users list" meta:resourcekey="lblTitleResource1"></asp:Label>
    </h1>
</asp:Content>

<%-- GLAVNI SADRŽAJ --%>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <%-- harmonika i panel grupa --%>
    <div id="MyAccordion" class="panel-group">
        <%-- GRID VIEW --%>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#MyAccordion" href="#gridViewContent">Grid view
                    </a>
                </h4>
            </div>
            <%-- sadržaj grid viewa --%>
            <div id="gridViewContent" class="panel-collapse collapse in">
                <div class="panel-body">
                    <asp:GridView ID="mojGV" runat="server" AutoGenerateColumns="False" DataKeyNames="IDUser" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="myGridView_RowDataBound" OnRowCancelingEdit="myGridView_RowCancelingEdit" OnRowEditing="myGridView_RowEditing" OnRowUpdating="myGridView_RowUpdating" CssClass="table table-hover" meta:resourcekey="myGridViewResource1">
                        <Columns>
                            <asp:TemplateField HeaderText="First Name" meta:resourcekey="TemplateFieldResource1"></asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" meta:resourcekey="TemplateFieldResource2"></asp:TemplateField>
                            <asp:TemplateField HeaderText="E-mail addresses" meta:resourcekey="TemplateFieldResource3"></asp:TemplateField>
                            <asp:TemplateField HeaderText="Telephone" meta:resourcekey="TemplateFieldResource4"></asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" meta:resourcekey="TemplateFieldResource5"></asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" meta:resourcekey="CommandFieldResource1" ButtonType="Button" CausesValidation="False" >
                            <ControlStyle CssClass="btn-link" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </div>
            </div>
        </div>


        <%-- ************************************************************************** --%>
        <%-- REPEATER --%>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#MyAccordion" href="#repeaterContent">Repeater
                    </a>
                </h4>
            </div>
            <%-- sadržaj repeatera --%>
            <div id="repeaterContent" class="panel-collapse collapse">
                <div class="panel-body">
                    <table class="table table-hover">
                        <asp:Repeater ID="myRepeater" runat="server" OnItemDataBound="myRepeater_ItemDataBound">
                            <HeaderTemplate>
                                <tr style="color: White; background-color: #333333; font-weight: bold;">
                                    <td>
                                        <asp:Label runat="server" Text="<%$ Resources:RepeaterResources, lblFirstName %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="<%$ Resources:RepeaterResources, lblLastName %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="<%$ Resources:RepeaterResources, lblEmails %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="<%$ Resources:RepeaterResources, lblTelephone %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="<%$ Resources:RepeaterResources, lblStatus %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="<%$ Resources:RepeaterResources, lblCity %>"></asp:Label></td>
                                    <td></td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label Style="font-weight: normal" ID="lblFistName" runat="server" Text='<%# Eval("FirstName") %>' meta:resourcekey="lblFistNameResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label Style="font-weight: normal" ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' meta:resourcekey="lblLastNameResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label Style="font-weight: normal" ID="lblEmails" runat="server" Text='emails...' meta:resourcekey="lblEmailsResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label Style="font-weight: normal" ID="lblTelephone" runat="server" Text='<%# Eval("Telephone") %>' meta:resourcekey="lblTelephoneResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label Style="font-weight: normal" ID="lblStatus" runat="server" Text='status...' meta:resourcekey="lblStatusResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label Style="font-weight: normal" ID="lblCity" runat="server" Text='city...' meta:resourcekey="lblCityResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandArgument='<%# Eval("IDUser") %>' ID="lbtnEdit" runat="server" Text="<%$ Resources:RepeaterResources, lbtnEdit %>" CssClass="btn btn-primary btn-sm"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
            <%-- GOTOVO --%>
        </div>
    </div>
</asp:Content>
