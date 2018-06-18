using RWAWebForms.Models;
using RWAWebForms.Models.BL;
using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWAWebForms
{
    public partial class Login : MyPage
    {
        // delimiter je | jer PwdManager radi s MD5 koji ne proizvodi taj znak
        private const char DELIMITER = '|';

        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        // --- REMEMBER ME cookie - provjerava ako postoji user taj
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            if (Request.Cookies["RememberMeUser"] != null)
            {
                // ak postoji cookie i ispravnog je formata, ide dalje
                string[] details = Request.Cookies["RememberMeUser"].Value.Split(DELIMITER);
                if (details.Length < 2)
                {
                    return;
                }
                // je li app admin
                if (LoginIsApplicationAdmin(details[0], details[1]))
                {
                    RedirectSuccessfulLogin(Application["ApplicationAdmin"] as User);
                }
                // je li neki registrirani korisnik
                else if (LoginIsRegisteredUser(details[0], details[1]))
                {
                    RedirectSuccessfulLogin(DataManager.GetUserByEmail(details[0]));
                }
            }
        }

        // --- LOGIN FORMA - postoji li user s tim podacima
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtEmail.Text;
            string password = txtPassword.Text;
            // provjeri je li ALFA MATER user ADMIN :)
            if (LoginIsApplicationAdmin(userName, PasswordManager.CreateHash(password)))
            {
                AddRememberMeUserCookieIfChecked(userName, password);
                RedirectSuccessfulLogin(Application["ApplicationAdmin"] as User);
            }
            // traži iz DataManagera tog usera
            else if (LoginIsRegisteredUser(userName, PasswordManager.CreateHash(password)))
            {
                AddRememberMeUserCookieIfChecked(userName, password);
                RedirectSuccessfulLogin(DataManager.GetUserByEmail(userName));
            }
            // ak nije našao iz DataManagera
            else
            {
                lblNoUser.Visible = true;
                txtEmail.Focus();
            }
        }

        // --------- POMOĆNE za provjeru logina i izradu keksića ---------

        // provjeri je li app admin
        private bool LoginIsApplicationAdmin(string userName, string hashedPassword)
        {
            if ((userName == (Application["ApplicationAdmin"] as User).Emails[0].UserName) && PasswordManager.IsMatchingHash((Application["ApplicationAdmin"] as User).Password, hashedPassword))
            {
                return true;
            }
            return false;
        }

        // provjeri je li korisnik u bazi/file-u
        private bool LoginIsRegisteredUser(string userName, string hashedPassword)
        {
            User user = DataManager.GetUserByEmail(userName);
            if ((user != null) && PasswordManager.IsMatchingHash(user.Password, hashedPassword))
            {
                return true;
            }
            return false;
        }

        // redirecta, radi repo kuki po potrebi, u session meće tog korisnika iz kukija
        private void RedirectSuccessfulLogin(User user)
        {
            AddRepoCookieIfEmpty();
            Session["CurrentUser"] = user;
            Response.Redirect("~/UsersList.aspx");
        }

        // radi remember me user kuki - stavlja username i HASH PWD-a
        private void AddRememberMeUserCookieIfChecked(string userName, string password)
        {
            if (cbRemeberMe.Checked)
            {
                HttpCookie kuki = new HttpCookie("RememberMeUser");
                kuki.Expires = DateTime.Now.AddYears(1);
                string kukiValue = $"{userName}{DELIMITER}{PasswordManager.CreateHash(password)}";
                kuki.Value = kukiValue;
                Response.Cookies.Add(kuki); 
            }
        }

        // radi repo kuki
        private void AddRepoCookieIfEmpty()
        {
            if (Request.Cookies["chosenRepo"] == null)
            {
                HttpCookie kuki = new HttpCookie("chosenRepo");
                kuki.Value = "2";
                kuki.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(kuki);
            }
        }

        protected override void ConfigIsLoginPage()
        {
            IsLoginPage = true;
        }

        protected override void ConfigIsAdminOnlyPage()
        {
            IsAdminOnlyPage = false;
        }
    }
}