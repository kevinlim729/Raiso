using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raiso.View
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateNavBar();
        }
        private void GenerateNavBar()
        {
            HasCustomerCookie();

            string navBarHtml = "<ul>";
            navBarHtml += "<li><a href='Cart.aspx'>Cart</a></li>";
            navBarHtml += "<li><a href='Transaction.aspx'>Transaction</a></li>";
            navBarHtml += "<li><a href='UpdateProfile.aspx'>Update Profile</a></li>";

            navBarHtml += "</ul>";

            NavBarPlaceHolder.Controls.Add(new Literal { Text = navBarHtml });
            
             
            
        }

        private void HasCustomerCookie()
        {
            // Check if the cookie exists
            HttpCookie userRoleCookie = HttpContext.Current.Request.Cookies["UserRoleCookie"];

            // redirect to home page if the cookie is not admin
            if (userRoleCookie == null || userRoleCookie["Role"] != "customer")
            {
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}