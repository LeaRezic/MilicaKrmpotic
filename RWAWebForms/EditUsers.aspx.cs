using RWAWebForms.Controls;
using RWAWebForms.Models;
using System;
using System.Web;
using RWAWebForms.Models.Entities;

namespace RWAWebForms
{
    public partial class DisplayUsers : MyPage
    {
        private char COOKIE_DELIMITER = '#';

        protected override void ConfigIsLoginPage()
        {
            IsLoginPage = false;
        }
        protected override void ConfigIsAdminOnlyPage()
        {
            IsAdminOnlyPage = true;
        }
        // ovo naslijedi i EditOneUser, pa je Page_Load virtual, prikazuje 1 ili SVE ovisno o QueryStringu
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            // ---- PRIKAZ JEDNEGA ili SVIJU
            if (Request.QueryString["UserID"] != null)
            {
                string decodedId = Server.UrlDecode(Request.QueryString["UserID"]);
                int id = int.Parse(decodedId);
                ShowUserControl(DataManager.GetUser(id));
            }
            else
            {
                DataManager.GetUsers().ForEach(u => ShowUserControl(u));
            }
            // TU ZA COOKIE ?
            if (Request.Cookies["myNotify"] != null)
            {
                string[] details = Request.Cookies["myNotify"].Value.Split(COOKIE_DELIMITER);
                string toastrType = details[0];
                string fullUserName = details[1];
                string message = details[2];
                ClientScript.RegisterStartupScript(GetType(), "myToastr", $"showToastr('{toastrType}','{fullUserName}<br>{message}')", true);
                Response.Cookies["myNotify"].Expires = DateTime.Now.AddDays(-1);
                Request.Cookies["myNotify"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        // ------ pomoćna zaprikaz ------
        private void ShowUserControl(User u)
        {
            DisplayUserControl duc = LoadControl("~/Controls/DisplayUserControl.ascx") as DisplayUserControl;
            duc.MyUser = u;
            // ako je ulogiran netko, disable-a mu status ddl i btn delete user
            if ((Session["CurrentUser"] as User) != null && u.IDUser == (Session["CurrentUser"] as User).IDUser)
            {
                duc.DisableDeleteButtonAndDdlStatus();
            }
            duc.OnUpdateClick += Duc_OnUpdateClick;
            duc.OnDeleteClick += Duc_OnDeleteClick;
            duc.OnEmailUpdateClick += Duc_OnEmailUpdateClick;
            phCustomControle.Controls.Add(duc);
        }

        // ------ PRETPLATE - zovu BL managera i rade kuki za TOASTR
        // delete
        private void Duc_OnDeleteClick(User user)
        {
            DataManager.DeleteUser(user);
            SendNotifyCookie("warning", user.ToString(), Resources.ToastrResources.DeleteMessage);
        }
        // update
        private void Duc_OnUpdateClick(User user)
        {
            DataManager.UpdateUser(user);
            SendNotifyCookie("success", user.ToString(), Resources.ToastrResources.UpdateMessage);
        }
        // update email
        private void Duc_OnEmailUpdateClick(User user)
        {
            DataManager.UpdateUser(user);
            SendNotifyCookie("info", user.ToString(), Resources.ToastrResources.EmailMessage);
        }

        // ------ POMOĆNE NEKE ------
        // pomoćna za kuki
        private void SendNotifyCookie(string toastrType, string user, string message)
        {
            HttpCookie kuki = new HttpCookie("myNotify");
            kuki.Value = $"{toastrType}{COOKIE_DELIMITER}{user}{COOKIE_DELIMITER}{message}";
            Response.Cookies.Add(kuki);
            RedirectUrl();
        }

        // VIRTUAL - jer EditOneUser mora drugačije
        protected virtual void RedirectUrl() => Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);

        
    }
}