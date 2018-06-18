using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                // DOVRŠIT OVI DIO ---------------------------------------------------
                btnEmailAdmin.OnClientClick = $"return window.open('mailto:{currentUser.Emails[0].UserName}','RWA je najjači!')";
                //lbtnEmailAdmin.Text = $"{currentUser.ToString()}";
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
            if (Request.Cookies["notifyNonAdmin"] != null)
            {
                Response.Cookies["notifyNonAdmin"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("~/Login.aspx");
        }


    }
}