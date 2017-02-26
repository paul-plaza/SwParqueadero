using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appSisVen
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
               
           

        }

        private void Loguear()
        {
            Response.Redirect("~/Default.aspx");
        }


        protected void btnAcceder_Click1(object sender, EventArgs e)
        {
            Loguear();
        }
    }
}