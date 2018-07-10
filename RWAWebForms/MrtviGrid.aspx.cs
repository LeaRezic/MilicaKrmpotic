using RWAWebForms.Models;
using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RWAWebForms
{
    public partial class MrtviGrid : MyPage
    {
        protected override void ConfigIsAdminOnlyPage()
        {
            IsAdminOnlyPage = false;
        }

        protected override void ConfigIsLoginPage()
        {
            IsLoginPage = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        private void ShowData()
        {
            mojGV.DataSource = DataManager.GetUsers();
            mojGV.DataBind();
            myRepeater.DataSource = DataManager.GetUsers();
            myRepeater.DataBind();
        }

        protected void mojGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = mojGV.Rows[e.RowIndex];
            int IDUser = (int)mojGV.DataKeys[e.RowIndex].Value;
            User selectedUser = DataManager.GetUser(IDUser);
            // jednostavni podaci
            TextBox txtFirstName = Utils.GetControl<TextBox>(row.Cells[0].Controls);
            TextBox txtLastName = Utils.GetControl<TextBox>(row.Cells[1].Controls);
            TextBox txtTelephone = Utils.GetControl<TextBox>(row.Cells[3].Controls);
            CheckBox chbIsAdmin = Utils.GetControl<CheckBox>(row.Cells[4].Controls);
            // podaci za EMAJLE
            Repeater repeater = Utils.GetControl<Repeater>(row.Cells[2].Controls);
            List<RepeaterItem> repeaterItems = Utils.GetAllControlsOfType<RepeaterItem>(repeater.Controls);
            List<TextBox> emailInputList = new List<TextBox>();
            foreach (var item in repeaterItems)
            {
                emailInputList.AddRange(Utils.GetAllControlsOfType<TextBox>(item.Controls));
            }
            List<Email> updatedEmails = new List<Email>();
            foreach (TextBox tb in emailInputList)
            {
                int id = int.Parse(tb.Attributes["Data"]);
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
                IsAdmin = chbIsAdmin.Checked,
                Password = selectedUser.Password,
                Emails = updatedEmails,
                City = selectedUser.City
            };
            DataManager.UpdateUser(dummy);
            mojGV.EditIndex = -1;
            ShowData();
        }

        protected void mojGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            mojGV.EditIndex = -1;
            ShowData();
        }

        protected void mojGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            mojGV.EditIndex = e.NewEditIndex;
            ShowData();
        }


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

    }
}