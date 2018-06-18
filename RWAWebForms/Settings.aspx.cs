using RWAWebForms.Models;
using System;
using System.Web;

namespace RWAWebForms
{
    public partial class Settings : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // ako promijeni TEMU, mijenja cookie (koji se provjerava u MyPage na OnPreInit)
        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddCookie("myTheme", ddlTheme.SelectedValue);
        }

        // ako promijeni JEZIK, mijenja cookie (koji se provjerava u MyPage na InitializeCulture)
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddCookie("myLanguage", ddlLanguage.SelectedValue);
        }

        // ako promijeni REPO, mijenja cookie (koji se provjerava u MyPage na OnPreInit)
        protected void ddlRepository_SelectedIndexChanged(object sender, EventArgs e)
        {
            // odustane ako je odabrano 0 ili ako je isto što već je
            if (ddlRepository.SelectedValue == "0" || ddlRepository.SelectedValue == Request.Cookies["chosenRepo"].Value)
            {
                // ovo vrati na 0 da se "rifreša"
                ddlRepository.SelectedIndex = 0;
                return;
            }
            // ak je drugačije, stvori novi cookie i ubija session "current user"
            Session["CurrentUser"] = null;
            if (Request.Cookies["notifyNonAdmin"] != null)
            {
                Response.Cookies["notifyNonAdmin"].Expires = DateTime.Now.AddDays(-1);
            }
            AddCookie("chosenRepo", ddlRepository.SelectedValue, "~/Login.aspx");
        }

        // pomoćna za napravit cookie
        private void AddCookie(string cookieName, string cookieValue, string redirectPath = "self")
        {
            HttpCookie kuki = new HttpCookie(cookieName);
            kuki.Expires = DateTime.Now.AddYears(1);
            kuki.Value = cookieValue;
            Response.Cookies.Add(kuki);
            if (redirectPath == "self")
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
            else
            {
                Response.Redirect(redirectPath);
            }
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