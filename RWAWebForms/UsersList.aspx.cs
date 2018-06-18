using RWAWebForms.Models;
using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWAWebForms
{
    public partial class UsersList : MyPage
    {

        // toastr za non-admin cookie
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["notifyNonAdmin"] != null)
                {
                    ClientScript.RegisterStartupScript(GetType(), "toastrNonAdmin", $"toastr.warning('Za pristup stranici morate imati prava<br>Administratora');", true);
                    //ClientScript.RegisterStartupScript(GetType(), "text", "test('warning', 'neki string još')", true);
                    //ClientScript.RegisterStartupScript(GetType(), "text", "test('info', 'neki string još')", true);
                    //ClientScript.RegisterStartupScript(GetType(), "text", "test('success', 'neki string još')", true);
                }
            }
        }

    // kod svakog preLoada okidam da bi mi rowUpdating mogao dohvatit :D
    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);
        ShowData();
    }

    // pridruživanje izvora podataka grid-view-u i repeateru
    private void ShowData()
    {
        myGridView.DataSource = DataManager.GetUsers();
        myGridView.DataBind();
        myRepeater.DataSource = DataManager.GetUsers();
        myRepeater.DataBind();
    }

    // OVISNO O VRSTI BINDINGA, DRUGAČIJE SE STVARI ZBIVAJU NA POLJIMA
    protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // ak je redak s podacima
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // zeme id usera i nađe usera, napravi ddl i mećne ga di treba
            int IDUser = (int)myGridView.DataKeys[e.Row.RowIndex].Value;
            User user = DataManager.GetUser(IDUser);
            DropDownList ddlStatus = CreateDdlStatus(user.IsAdmin);
            e.Row.Cells[4].Controls.Add(ddlStatus);
            // ovisno o tome je li edit ili normal, radi text-boxe ili labele
            if (((e.Row.RowState & DataControlRowState.Edit) > 0))
            {
                GenerateEditTemplateItems(user, e);
                ddlStatus.Enabled = true;
            }
            else
            {
                GenerateTemplateItems(user, e);
            }
        }
    }

    // pomoćna, generira pojla za EDIT
    private void GenerateTemplateItems(User user, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Controls.Add(new MyLabel(user.FirstName));
        e.Row.Cells[1].Controls.Add(new MyLabel(user.LastName));
        string displayText = Utils.GenerateSendEmailLinks(user.Emails);
        e.Row.Cells[2].Text = displayText;
        e.Row.Cells[3].Controls.Add(new MyLabel(user.Telephone));
    }

    // pomoćna, generira polja za NE EDIT
    private void GenerateEditTemplateItems(User user, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Controls.Add(new MyEditTextBox(user.FirstName));
        e.Row.Cells[1].Controls.Add(new MyEditTextBox(user.LastName));
        foreach (Email email in user.Emails)
        {
            e.Row.Cells[2].Controls.Add(new MyEditTextBox(email.UserName, email.IDEmail));
        }
        e.Row.Cells[3].Controls.Add(new MyEditTextBox(user.Telephone));
    }

    // pomoćna, KREIRA DDL-STATUS
    private DropDownList CreateDdlStatus(bool isUserAdmin)
    {
        DropDownList ddlStatus = new DropDownList();
        ddlStatus.Items.AddRange(new ListItem[] { new ListItem { Text = "Administrator" }, new ListItem { Text = Resources.RepeaterResources.UserStatus } });
        ddlStatus.SelectedIndex = isUserAdmin ? 0 : 1;
        ddlStatus.CssClass = "form-control input-sm";
        ddlStatus.Width = 150;
        ddlStatus.Enabled = false;
        return ddlStatus;
    }

    // -------- OSTALI EVENTI na GRID-VIEW-u : editing, canceledit, rowupdating
    protected void myGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        myGridView.EditIndex = e.NewEditIndex;
        ShowData();
    }

    protected void myGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        myGridView.EditIndex = -1;
        ShowData();
    }

    protected void myGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = myGridView.Rows[e.RowIndex];
        int IDUser = (int)myGridView.DataKeys[e.RowIndex].Value;
        User selectedUser = DataManager.GetUser(IDUser);
        // jednostavni podaci
        TextBox txtFirstName = Utils.GetControl<TextBox>(row.Cells[0].Controls);
        TextBox txtLastName = Utils.GetControl<TextBox>(row.Cells[1].Controls);
        TextBox txtTelephone = Utils.GetControl<TextBox>(row.Cells[3].Controls);
        DropDownList ddlStatus = Utils.GetControl<DropDownList>(row.Cells[4].Controls);
        // podaci za EMAJLE
        List<TextBox> emailInputList = Utils.GetAllControlsOfType<TextBox>(row.Cells[2].Controls);
        List<Email> updatedEmails = new List<Email>();
        foreach (TextBox tb in emailInputList)
        {
            int id = int.Parse(tb.ID);
            string userName = tb.Text;
            updatedEmails.Add(new Email { IDEmail = id, UserName = userName });
        }
        // radi dummy-ja i daje ga data manageru
        User dummy = new User
        {
            IDUser = IDUser,
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            Telephone = txtTelephone.Text,
            IsAdmin = ddlStatus.SelectedIndex == 0,
            Password = selectedUser.Password,
            Emails = updatedEmails,
            City = selectedUser.City
        };
        DataManager.UpdateUser(dummy);
        myGridView.EditIndex = -1;
        ShowData();
    }
        

    // ------------ REPEATER
    protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int userID = int.Parse(((LinkButton)e.Item.FindControl("lbtnEdit")).CommandArgument);
            User user = DataManager.GetUser(userID);
            ((Label)e.Item.FindControl("lblStatus")).Text = user.IsAdmin ? "Administrator" : Resources.RepeaterResources.UserStatus;
            ((Label)e.Item.FindControl("lblCity")).Text = user.City.ToString();
            string displayText = Utils.GenerateSendEmailLinks(user.Emails);
            ((Label)e.Item.FindControl("lblEmails")).Text = displayText;
            string urlID = Server.UrlEncode(user.IDUser.ToString());
            ((LinkButton)e.Item.FindControl("lbtnEdit")).PostBackUrl = "~/EditOneUser.aspx?UserID=" + urlID;
        }
    }

        protected override void ConfigIsLoginPage()
        {
            IsLoginPage = false;
        }

        protected override void ConfigIsAdminOnlyPage()
        {
            IsAdminOnlyPage = false;
        }
    }
}