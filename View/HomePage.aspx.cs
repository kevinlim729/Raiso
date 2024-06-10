using Raiso.Controller;
using Raiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Raiso.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        RAisoController getcookie = new RAisoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure GenerateNavBar is called when the page loads
            GenerateNavBar();
        }

        private void GenerateNavBar()
        {
            string cookie = getcookie.redirect();

            if(cookie == null)
            {
                // Generate the navigation bar HTML
                string navBarHtml = "<ul>";
                navBarHtml += "<li><a href='HomePage.aspx'>Home</a></li>";
                navBarHtml += "<li><a href='LoginPage.aspx'>Login</a></li>";
                navBarHtml += "<li><a href='RegisterPage.aspx'>Register</a></li>";
                navBarHtml += "</ul>";

                // Add the navigation bar HTML to the placeholder
                NavBarPlaceHolder.Controls.Add(new Literal { Text = navBarHtml });
            }
            else if(cookie == "admin")
            {
                Response.Redirect(cookie);
            }
        }

        
    }
}
