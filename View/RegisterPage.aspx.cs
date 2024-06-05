using Raiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raiso.Repository;
using Raiso.Controller;


namespace Raiso.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserLoggedIn"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        protected void ValidateDOB(object source, ServerValidateEventArgs args)
        {
            DateTime dob;
            int age = -1;
            if (DateTime.TryParse(args.Value, out dob))
            {
                age = DateTime.Now.Year - dob.Year;
                if (dob > DateTime.Now.AddYears(-age)) age--;
            }
            args.IsValid = (age >= 1);
        }

        private bool ValidateDOB(string dobInput)
        {
            DateTime dob;
            int age = -1;
            if (DateTime.TryParse(dobInput, out dob))
            {
                age = DateTime.Now.Year - dob.Year;
                if (dob > DateTime.Now.AddYears(-age)) age--;
            }
            return (age >= 1) ? true : false;
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = txtUserame.Text;
            string password = txtPassword.Text;
            string dobInput = DOB.Text;
            DateTime dob;
            string gender = radiobtnGender.SelectedValue;
            string address = txtAddress.Text;

            if (!ValidateDOB(dobInput))
            {
                ErrorMessage.Text = "You must be at least 1 year old!";
                return;
            }
            if (!DateTime.TryParse(dobInput, out dob))
            {
                ErrorMessage.Text = "Please enter a valid date of birth.";
                return;
            }

            RAisoRepository newUser = new RAisoRepository();
            newUser.create(username, password, dob, gender, address);

            Response.Redirect("HomePage.aspx");
        }
    }
}

