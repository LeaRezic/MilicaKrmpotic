using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace RWAWebForms
{
    public class Global : System.Web.HttpApplication
    {

        public User ApplicationAdmin { get; private set; }

        // postavlja podatke za glavnog admina
        protected void Application_Start(object sender, EventArgs e)
        {
            List<Email> adminEmail = new List<Email>();
            adminEmail.Add(new Email { IDEmail = 0, UserName = "admin@mail.com" });
            ApplicationAdmin = new User {
                IDUser = 0,
                FirstName = "ADMIN",
                LastName = "ADMIN",
                Password = "123",
                IsAdmin = true,
                Emails = adminEmail
            };
            Application.Lock();
            Application["ApplicationAdmin"] = ApplicationAdmin;
            Application.UnLock();
            //Session["AdminUser"] = ApplicationAdmin;
        }

        // ovo možda maknem skroz
        protected void Application_Error(object sender, EventArgs e)
        {
            var serverError = Server.GetLastError() as HttpException;
            if (serverError != null)
            {
                if (serverError.GetHttpCode() == 404)
                {
                    Server.ClearError();
                    Server.Transfer("404Error.aspx");
                }
            }
            Exception ex = Server.GetLastError().GetBaseException();
            string err = Server.UrlEncode(ex.Message);
            Response.Redirect("~/CustomErrorPage.aspx?err=" + err);
        }
    }
}