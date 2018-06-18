using RWAWebForms.Models.BL;
using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace RWAWebForms.Models
{
    public abstract class MyPage : System.Web.UI.Page
    {
        // protected, budu koristili potomci
        protected UserManager DataManager { get; set; }
        protected bool IsLoginPage { get; set; }
        protected bool IsAdminOnlyPage { get; set; }

        protected abstract void ConfigIsLoginPage();
        protected abstract void ConfigIsAdminOnlyPage();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ConfigIsLoginPage();
            ConfigIsAdminOnlyPage();
        }

        // ako nije login, nek baci na login. Ako nije admin nek notificira
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsLoginPage)
            {
                if (Session["CurrentUser"] as User == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (IsAdminOnlyPage && !(Session["CurrentUser"] as User).IsAdmin)
                {
                    HttpCookie kuki = new HttpCookie("notifyNonAdmin");
                    Response.Cookies.Add(kuki);
                    Response.Redirect("~/UsersList.aspx");
                }
            }
        }

        // postavlja kulturu ovisno o LANGUAGE kukiju
        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            if (Request.Cookies["myLanguage"] != null)
            {
                var culture = Request.Cookies["myLanguage"].Value;
                if (culture != "0")
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                }
            }
        }

        // kukiji za TEMU i za CHOSEN REPO
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Request.Cookies["myTheme"] != null)
            {
                var theme = Request.Cookies["myTheme"].Value;
                if (theme != "0")
                {
                    this.Theme = theme;
                }
            }
            // za repo, ak ima kuki radi UserManager s željenim, a ak nema, onda radi defaultni repo
            if (Request.Cookies["chosenRepo"] != null)
            {
                string repo = Request.Cookies["chosenRepo"].Value;
                DataManager = new UserManager(repo);
            }
            else
            {
                DataManager = new UserManager();
            }
        }

    }
}