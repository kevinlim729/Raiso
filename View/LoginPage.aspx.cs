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
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie["Username"] = username;

                bool isAdmin = checkAdmin(username);

                if (isAdmin)
                {
                    cookie.Expires = DateTime.Now.AddHours(6);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddHours(12);
                }

                Response.Cookies.Add(cookie);

                Response.Redirect("HomePage.aspx");
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