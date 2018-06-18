using RWAWebForms.Models;
using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace RWAWebForms
{
    public partial class AddNewUser : MyPage
    {

        // prikazuje toastr po potrebi i poziva punjenje ddl-ova
        protected void Page_Load(object sender, EventArgs e)
        {
            // svoj interni toastr prikaže, ako je prethodno uspješno dodan neki user
            if (Request.Cookies["NotifyAddedUser"] != null)
            {
                string nameSurname = Request.Cookies["NotifyAddedUser"].Value;

                //ClientScript.RegisterStartupScript(GetType(), "toastrAddedUser", $"toastr.info('{nameSurname}<br>uspješno dodan');", true);
                ClientScript.RegisterStartupScript(GetType(), "myToastr", $"showToastr('info','{nameSurname}<br>{Resources.ToastrResources.AddMessage}')", true);
                Response.Cookies["NotifyAddedUser"].Expires = DateTime.Now.AddDays(-1);
            }
            // popuni ddl-ove ako nije post-back
            if (!IsPostBack)
            {
                txtFirstName.Focus();
                FillDdlCities();
                FillDdlStatus();
            }
        }

        // punjenje ddl-ova
        private void FillDdlStatus()
        {
            ddlStatus.Items.AddRange(new ListItem[] { new ListItem { Text = "Administrator" }, new ListItem { Text = Resources.RepeaterResources.UserStatus } });
        }
        private void FillDdlCities()
        {
            foreach (Cities city in Enum.GetValues(typeof(Cities)))
            {
                ddlCity.Items.Add(new ListItem { Text = city.ToString(), Value = city.ToString() });
            }
        }

        // prikazivanje još mailova
        protected void lbAddMoreEmailAddresses_Click(object sender, EventArgs e)
        {
            if (!divEmail2.Visible)
            {
                divEmail2.Visible = true;
            }
            else if (divEmail2.Visible)
            {
                divEmail3.Visible = true;
                lbAddMoreEmailAddresses.Visible = false;
            }
        }

        // dodavanje novog usera
        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            List<Email> emails = new List<Email>();
            emails.Add(new Email { IDEmail = -1, UserName = txtEmail1.Text });
            if (divEmail2.Visible)
            {
                emails.Add(new Email { IDEmail = -1, UserName = txtEmail2.Text });
                if (divEmail3.Visible)
                {
                    emails.Add(new Email { IDEmail = -1, UserName = txtEmail3.Text });
                }
            }
            User user = new User
            {
                IDUser = -1,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Telephone = txtTelephone.Text,
                Password = txtPassword.Text,
                Emails = emails,
                City = (Cities)Enum.Parse(typeof(Cities), ddlCity.SelectedItem.Text),
                IsAdmin = (ddlStatus.SelectedItem.Text == "Administrator")
            };
            DataManager.AddUserFromInput(user);
            // stvori i kuki za notifikaciju da je dodan user
            CreateNotifyCookie(user.ToString());
        }

        // pomoćna za kreirat kuki
        private void CreateNotifyCookie(string nameSurname)
        {
            HttpCookie kuki = new HttpCookie("NotifyAddedUser");
            kuki.Value = nameSurname;
            Response.Cookies.Add(kuki);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected override void ConfigIsLoginPage()
        {
            IsLoginPage = false;
        }

        protected override void ConfigIsAdminOnlyPage()
        {
            IsAdminOnlyPage = true;
        }
    }
}