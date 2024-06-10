using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raiso.Controller
{
    public class RAisoController
    {
        public string redirect()
        {
            string cookie = getCookie();
            // Perform redirection based on the cookie value
            if (cookie == "admin")
            {
                return "~/View/Admin/AdminPage.aspx";
            }
            else if (cookie == "customer")
            {
                return "~/View/Customer/CustomerPage.aspx";
            }
            return null;
        }
        private string getCookie()
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