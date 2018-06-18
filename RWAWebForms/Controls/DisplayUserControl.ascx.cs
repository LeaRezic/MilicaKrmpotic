using RWAWebForms.Models;
using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWAWebForms.Controls
{
    public partial class DisplayUserControl : System.Web.UI.UserControl
    {
        // DELEGATI i EVENTI - vjerojatno bi se dalo ljepše :D
        // za update osobe
        public delegate void OnUpdateClickEventHandler(User user);
        public event OnUpdateClickEventHandler OnUpdateClick;
        // različito za emajl zbog toastra
        public delegate void OnEmailUpdateClickEventHandler(User user);
        public event OnEmailUpdateClickEventHandler OnEmailUpdateClick;
        // za delete osobe
        public delegate void OnDeleteClickEventHandler(User user);
        public event OnDeleteClickEventHandler OnDeleteClick;

        // varijable neke - kad se postavlja MyUser, prikaže podatke u kk-u
        private User myUser;
        public User MyUser
        {
            get { return myUser; }
            set
            {
                myUser = value;
                ShowData();
            }
        }

        // -------------- TEST client ID TEST -----------------
        //public string BtnDeleteClientID { get { return btnDelete.ClientID; } }

        // -------------- na page load se doda JS alert na DELETE BUTTON

        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.OnClientClick = "return confirm('Potvrdite brisanje osobe?')";
        }

        // ---------- PRIKAZ PODATAKA ----------
        private void ShowData()
        {
            txtFirstName.Text = myUser.FirstName;
            txtLastName.Text = myUser.LastName;
            txtTelephone.Text = myUser.Telephone;
            txtPassword.Text = myUser.Password;
            FillDdlEmails(myUser.Emails);
            txtEmail.Text = myUser.Emails[0].UserName;
            FillDdlStatus();
            SelectDdlStatus();
            FillDdlCities();
            SelectDdlCities();
        }

        // ---------- pomoćne prikazne ----------
        // ddl email
        private void FillDdlEmails(List<Email> emails)
        {
            foreach (Email email in emails)
            {
                ddlEmail.Items.Add(new ListItem { Text = email.UserName, Value = email.IDEmail.ToString() });
            }
        }
        public void showEmail(Email e)
        {
            txtEmail.Text = e.ToString();
        }
        // ddl status
        private void FillDdlStatus()
        {
            //foreach (UserStatus status in Enum.GetValues(typeof(UserStatus)))
            //{
            //    ddlStatus.Items.Add(new ListItem { Text = status.ToString(), Value = status.ToString() });
            //}
            ddlStatus.Items.AddRange(new ListItem[] { new ListItem { Text = "Administrator" }, new ListItem { Text = Resources.RepeaterResources.UserStatus } });
        }
        private void SelectDdlStatus()
        {
            if (myUser.IsAdmin)
            {
                ddlStatus.SelectedIndex = 0;
            }
            else
            {
                ddlStatus.SelectedIndex = 1;
            }
        }
        // ddl cities
        private void FillDdlCities()
        {
            foreach (Cities city in Enum.GetValues(typeof(Cities)))
            {
                ddlCity.Items.Add(new ListItem { Text = city.ToString(), Value = city.ToString() });
            }
        }
        private void SelectDdlCities()
        {
            ddlCity.SelectedIndex = (int)myUser.City;
        }

        // disablea DELETE button i STATUS ddl ako mu se tako kaže (da admin ne bi sam sebe izbacio)
        public void DisableDeleteButtonAndDdlStatus()
        {
            btnDelete.Enabled = false;
            ddlStatus.Enabled = false;
        }

        // ---------- RIFREŠKANJE ----------
        public void RefreshControl(User user)
        {
            MyUser = user;
            ShowData();
        }

        // ---------- UPDATE USER EVENT ----------
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            OnUpdateClick?.Invoke(new User
            {
                IDUser = myUser.IDUser,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Telephone = txtTelephone.Text,
                Password = txtPassword.Text,
                Emails = myUser.Emails,
                City = (Cities)Enum.Parse(typeof(Cities), ddlCity.SelectedItem.Text),
                IsAdmin = (ddlStatus.SelectedItem.Text == "Administrator")
            });
        }

        // ---------- DELETE USER EVENT ----------
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClick?.Invoke(MyUser);
        }

        // ---------- UPDATE EMAIL EVENT ----------
        protected void ddlEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Text = myUser.Emails[ddlEmail.SelectedIndex].UserName;

        }
        protected void btnEditEmail_Click(object sender, EventArgs e)
        {
            myUser.Emails[ddlEmail.SelectedIndex].UserName = txtEmail.Text;
            OnEmailUpdateClick?.Invoke(myUser);
        }
        
    }
}