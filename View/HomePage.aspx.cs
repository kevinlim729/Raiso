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
        

        private void GenerateNavBar()
        {
            string isLoggedIn = IsUserLoggedIn();

            string navBarHtml = "<ul>";

            navBarHtml += "<li><a href='HomePage.aspx'>Home</a></li>";
            navBarHtml += "<li><a href='LoginPage.aspx'>Login</a></li>";
            navBarHtml += "<li><a href='RegisterPage.aspx'>Register</a></li>";
            navBarHtml += "</ul>";

            NavBarPlaceHolder.Controls.Add(new Literal { Text = navBarHtml });
        }




        private string IsUserLoggedIn()
        {
            // Check if the cookie exists
            HttpCookie userRoleCookie = HttpContext.Current.Request.Cookies["UserRoleCookie"];

            // If the cookie does not exist, return "none"
            if (userRoleCookie == null)
            {
                return "none";
            }

            // Read the value of the "Role" from the cookie
            string userRole = userRoleCookie["Role"];

            // Return the user role if it is "admin" or "customer", otherwise return "none"
            if (userRole == "admin" || userRole == "customer")
            {
                return userRole;
            }

            return "none";
        }



    }
}
