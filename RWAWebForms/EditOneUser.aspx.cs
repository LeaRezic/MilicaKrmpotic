using System;
using System.Web;

namespace RWAWebForms
{
    public partial class EditOneUser : DisplayUsers
    {
        public int currentUserID { get; set; }

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (Request.QueryString["UserID"] != null)
            {
                string decodedId = Server.UrlDecode(Request.QueryString["UserID"]);
                currentUserID = int.Parse(decodedId);
            }
        }

        protected override void RedirectUrl()
        {
            if (DataManager.GetUser(currentUserID) == null)
            {
                Response.Redirect("~/EditUsers.aspx");
            }
            Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath + "?UserID=" + Server.UrlEncode(currentUserID.ToString()));
        }
        
    }
}