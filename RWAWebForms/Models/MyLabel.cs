using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RWAWebForms.Models
{
    public class MyLabel : Label
    {
        public MyLabel(string text) : base()
        {
            Text = text;
            //CssClass = "gridViewLabels";
        }
    }
}