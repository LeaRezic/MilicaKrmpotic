using RWAWebForms.Models.Entities;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace RWAWebForms.Models
{
    public static class Utils
    {
        // jednu kontrolu dohvaća
        public static T GetControl<T> (ControlCollection parent)
        {
            foreach (var ctrl in parent)
            {
                if (ctrl is T)
                {
                    return (T)ctrl;
                }
            }
            return default(T);
        }

        // listu kontrola dohvaća
        public static List<T> GetAllControlsOfType<T>(ControlCollection parent)
        {
            List<T> controlsList = new List<T>();
            foreach (var ctrl in parent)
            {
                if (ctrl is T)
                {
                    controlsList.Add((T)ctrl);
                }
            }
            return controlsList;
        }

        // generira listu linkova s href:mailto
        public static string GenerateSendEmailLinks(List<Email> emails)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Email e in emails)
            {
                if (e.UserName != emails[0].UserName)
                {
                    sb.Append("<br/>");
                }
                sb.Append($"<a href='mailto:{e.UserName}'> {e.UserName} </a>");
            }
            return sb.ToString();
        }

    }
}