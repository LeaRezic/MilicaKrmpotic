using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWAWebForms.Models
{
    [SupportsEventValidation]
    public class MyEditTextBox : TextBox
    {
        public MyEditTextBox(string text, int id = -1) : base()
        {
            Text = text;
            CssClass = "form-control input-sm";
            if (id != -1)
            {
                ID = id.ToString();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            
            base.Render(writer);
        }
    }
}