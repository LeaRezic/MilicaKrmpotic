using RWAWebForms.Models.Entities;
using System;

namespace RWAWebForms
{
    public partial class Main : System.Web.UI.MasterPage
    {
        // postavlja puce za mailto admin, tekst i JS (il kaj već bude to) 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {
                User currentUser = Session["CurrentUser"] as User;
                btnEmailAdmin.Text = $"{currentUser.ToString()}";
                btnEmailAdmin.Attributes["href"] = $"mailto:{currentUser.Emails[0].UserName}";
            }
        }

        // ispisuje label s repozitorijem (ako odista postoji cookie)
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (Request.Cookies["chosenRepo"] != null)
            {
                string repo = Request.Cookies["chosenRepo"].Value == "1" ? $"{Resources.MasterStrings.repoOptionTextFile}" : $"{Resources.MasterStrings.repoOptionDB}";
                lblRepo.Text = $"{Resources.MasterStrings.lblRepoText}{repo}";
            }
        }

        // ak se netko odlogira, ubije currentUsera i ide na login
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["CurrentUser"] = null;
            if (Request.Cookies["RememberMeUser"] != null)
            {
                Response.Cookies["RememberMeUser"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("~/Login.aspx");
        }


    }
}