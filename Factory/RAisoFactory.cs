using Raiso.Model;
using Raiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace Raiso.Factory
{
    public class RAisoFactory
    {
        public static MsUser Create(
            string username, string password, DateTime dob, string gender, string address, string phone
            )
        {
            RAisoRepository repo = new RAisoRepository();
            MsUser user = new MsUser();

            user.UserID = repo.generateUserID();
            user.UserName = username;
            user.UserPassword = password;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserAddress = address;
            user.UserPhone = phone;
            user.UserRole = "customer";

            return user;
        }
    }
}