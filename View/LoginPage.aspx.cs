using Raiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raiso.Repository;

namespace Raiso.View
{
    public partial class LoginPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isAuthenticated = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                HttpCookie cookie;

                bool isAdmin = checkAdmin(username);
                string pageRedirect = "~/";

                if (isAdmin)
                {
                    cookie = new HttpCookie("admin");
                    pageRedirect += "Admin/AdminPage.aspx";
                }
                else
                {
                    cookie = new HttpCookie("customer");
                    pageRedirect += "Customer/CustomerPage.aspx";
                }

                cookie.Expires = DateTime.Now.AddHours(12);
                cookie["Username"] = username;
                Response.Cookies.Add(cookie);

                Response.Redirect(pageRedirect);
            }
            else
            {
                lblErrorMessage.Text = "Invalid username or password.";
                lblErrorMessage.Visible = true;
            }
        }

        private bool checkAdmin(string username)
        {
            RAisoRepository repo = new RAisoRepository();
            string isAdmin = repo.getUserRolebyUserName(username);
            return (isAdmin == "admin") ? false : true;
        }

        private bool AuthenticateUser(string username, string password)
        {
            RAisoRepository repo = new RAisoRepository();
            return repo.verifyUsernameAndPassword(username, password);

        }

    }
}