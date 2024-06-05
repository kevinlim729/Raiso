using Raiso.Factory;
using Raiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            string username, string password, DateTime dob, string gender, string address
            )
        {

            try
            {
                MsUser newUser = RAisoFactory.Create(username, password, dob, gender, address);
                db.MsUsers.Add(newUser);
                db.SaveChanges();

                // check if the user has been added to the database
                int newUserID = getUserIDByUsername(username);
                MsUser addedUser = db.MsUsers.SingleOrDefault(u => u.UserID == newUserID);

                if (addedUser != null)
                {
                    
                    return true;
                }
                else
                {
                    throw new Exception("The user was not added to the database due to an error.");
                }

            }catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the user: " + ex.Message);
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