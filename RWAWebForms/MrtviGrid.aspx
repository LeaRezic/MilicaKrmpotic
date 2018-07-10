<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MrtviGrid.aspx.cs" Inherits="RWAWebForms.MrtviGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        // pozivanje svega na window.onload
        window.onload = function () {
            showMasterLoginEmailButtons();
        };
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Jednostavnije - Repeater u Gridu (divnokrasno)"></asp:Label>
    </h1>
</asp:Content>



<%-- GLAVNI SADRŽAJ --%>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
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
                    <asp:GridView CssClass="table table-hover" ID="mojGV" runat="server" AutoGenerateColumns="False" DataKeyNames="IDUser" OnRowCancelingEdit="mojGV_RowCancelingEdit" OnRowEditing="mojGV_RowEditing" OnRowUpdating="mojGV_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                <ControlStyle CssClass="form-control" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                <ControlStyle CssClass="form-control" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="E-mail">
                                <EditItemTemplate>
                                        <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Emails") %>'>
                                            <ItemTemplate>
                                                        <asp:TextBox Data='<%# Eval("IDEmail") %>'
                                                            Text='<%# Eval("UserName") %>'
                                                            runat="server"
                                                            CssClass="form-control"/>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Emails") %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlEmail"
                                                Text='<%# Eval("UserName") %>'
                                                NavigateUrl='<%# Bind("UserName", "mailto:{0}") %>'
                                                runat="server"
                                                style="display:block"/>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Telephone" HeaderText="Telephone">
                                <ControlStyle CssClass="form-control" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Admin">
                                <EditItemTemplate>
                                    <asp:CheckBox runat="server" Checked='<%# Eval("IsAdmin") %>'></asp:CheckBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox Enabled="false" runat="server" Checked='<%# Eval("IsAdmin") %>'></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True">
                                <ControlStyle CssClass="btn-link" />
                            </asp:CommandField>
                        </Columns>
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
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



<%--<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <asp:GridView CssClass="table table-hover" ID="mojGV" runat="server" AutoGenerateColumns="False" Width="1179px" DataKeyNames="IDUser" OnRowCancelingEdit="mojGV_RowCancelingEdit" OnRowEditing="mojGV_RowEditing" OnRowUpdating="mojGV_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" >
            <ControlStyle CssClass="form-control" />
            </asp:BoundField>
            <asp:BoundField DataField="LastName" HeaderText="Last Name" >
            <ControlStyle CssClass="form-control" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="E-mail">
                <EditItemTemplate>
                    <table>
                        <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Emails") %>'>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox Text='<%# Eval("UserName") %>' runat="server" CssClass="form-control" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </EditItemTemplate>
                <ItemTemplate>
                    <table>
                        <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Emails") %>'>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="hlEmail"
                                            Text='<%# Eval("UserName") %>'
                                            NavigateUrl='<%# Bind("UserName", "mailto:{0}") %>'
                                            runat="server"/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Telephone" HeaderText="Telephone" >
            <ControlStyle CssClass="form-control" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Status"></asp:TemplateField>
            <asp:CommandField ShowEditButton="True">
            <ControlStyle CssClass="btn-link" />
            </asp:CommandField>
        </Columns>
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
</asp:Content>--%>
