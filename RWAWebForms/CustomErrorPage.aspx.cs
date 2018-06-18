using RWAWebForms.Models;
using System;

namespace RWAWebForms
{
    public partial class CustomErrorPage : MyPage
    {
        protected override void ConfigIsAdminOnlyPage()
        {
            IsAdminOnlyPage = false;
        }

        protected override void ConfigIsLoginPage()
        {
            IsLoginPage = false;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            IsAdminOnlyPage = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["err"] != null)
            {
                var error = Request.QueryString["err"];
                lblErrorDetails.Text = Server.UrlDecode(error);
            }
        }
    }
}