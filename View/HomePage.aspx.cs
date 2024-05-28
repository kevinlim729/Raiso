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
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateNavBar();
        }

        private void GenerateNavBar()
        {
            bool isLoggedIn = IsUserLoggedIn();
            string userRole = GetUserRole();

            string navBarHtml = "<ul>";

            // navBarHtml += "<li><a href='HomePage.aspx'>Home</a></li>";

            if (!isLoggedIn)
            {
                navBarHtml += "<li><a href='LoginPage.aspx'>Login</a></li>";
                navBarHtml += "<li><a href='RegisterPage.aspx'>Register</a></li>";
            }
            else
            {
                if (userRole == "customer")
                {
                    navBarHtml += "<li><a href='Cart.aspx'>Cart</a></li>";
                    navBarHtml += "<li><a href='Transaction.aspx'>Transaction</a></li>";
                    navBarHtml += "<li><a href='UpdateProfile.aspx'>Update Profile</a></li>";
                }
                else if (userRole == "admin")
                {
                    navBarHtml += "<li><a href='TransactionReport.aspx'>Transaction</a></li>";
                    navBarHtml += "<li><a href='UpdateProfile.aspx'>Update Profile</a></li>";
                }
                navBarHtml += "<li><a href='Logout.aspx'>Logout</a></li>";
            }

            navBarHtml += "</ul>";

            NavBarPlaceHolder.Controls.Add(new Literal { Text = navBarHtml });
        }

        private bool IsUserLoggedIn()
        {
            // Replace with your actual logic to check if the user is logged in
            return HttpContext.Current.Session["UserLoggedIn"] != null;
        }

        private string GetUserRole()
        {
            // Replace with your actual logic to get the user's role
            return HttpContext.Current.Session["UserRole"] as string;
        }
    }
}
