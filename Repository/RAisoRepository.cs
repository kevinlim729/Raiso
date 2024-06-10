using Raiso.Factory;
using Raiso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;

namespace Raiso.Repository
{
    public class RAisoRepository
    {
        //RAiso_Database_Entities db = new RAiso_Database_Entities();
        RAiso_Database_Entities db = new RAiso_Database_Entities();

        public int generateUserID()
        {
            int lastID = db.MsUsers.Select(u => u.UserID).DefaultIfEmpty(0).Max();
            return lastID + 1;
        }


        public int getUserIDByUsername(string username)
        {
            return (
                from i in db.MsUsers
                where i.UserName == username
                select i.UserID
                ).ToList().FirstOrDefault();
        }

        public MsUser getUsername(String username)
        {
            return (
                from names in db.MsUsers
                where names.UserName == username
                select names
                ).FirstOrDefault();
        }

        public MsUser getPassword(String username, String password)
        {
            MsUser user = (
                from u in db.MsUsers
                where u.UserName == username
                select u
            ).FirstOrDefault();

            return (user != null && user.UserPassword == password) ? user : null;
        }

        public bool verifyUsernameAndPassword(String username, String password)
        {
            MsUser user = getPassword(username, password);
            return (user == null) ? false : true;
        }

        public string getUserRolebyUserName(string username)
        {
            MsUser user = (
                from u in db.MsUsers
                where u.UserName == username
                select u
                ).FirstOrDefault();
            return user?.UserRole;
        }


    public bool create(
        string username, string password, DateTime dob, string gender, string address, string phone
        )
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                    dob == default(DateTime) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(address))
                {
                    throw new ArgumentException("One or more inputs are invalid.");
                }

                // Check if the username already exists
                bool usernameExists = db.MsUsers.Any(u => u.UserName == username);
                if (usernameExists)
                {
                    throw new Exception("Username already exists.");
                }

                // Create new user instance using the factory
                MsUser newUser = RAisoFactory.Create(username, password, dob, gender, address, phone);

                // Add new user to the database context
                db.MsUsers.Add(newUser);

                // Save changes to the database
                db.SaveChanges();

                // Retrieve the new user's ID
                int newUserID = getUserIDByUsername(username);

                // Verify that the user was added correctly
                MsUser addedUser = db.MsUsers.SingleOrDefault(u => u.UserID == newUserID);

                if (addedUser != null)
                {
                    return true;
                }
                else
                {
                    throw new Exception("The user was not added to the database due to an error.");
                }
            }
            catch (DbEntityValidationException ex)
            {
                // Extract and log detailed validation error messages
                var validationErrors = ex.EntityValidationErrors
                    .SelectMany(ve => ve.ValidationErrors)
                    .Select(e => $"{e.PropertyName}: {e.ErrorMessage}");
                string fullErrorMessage = "Validation errors: " + string.Join("; ", validationErrors);

                throw new Exception("An error occurred while creating the user: " + fullErrorMessage, ex);
            }
            catch (Exception ex)
            {
                // Log the exception (if a logging system is in place)
                // Logger.LogError(ex);

                throw new Exception("An error occurred while creating the user: " + ex.Message, ex);
            }
        }


    /*
     public MsFruit GetFruitByID(String id)
    {
        return (from fruit in db.MsFruits where fruit.FruitID == id select fruit).FirstOrDefault();
    }
     */
}
}