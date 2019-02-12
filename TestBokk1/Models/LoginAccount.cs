using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBokk1.Models
{
    public class LoginAccount
    {
        public static int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginAccount()
        {

        }
        public LoginAccount(string username, string password)
        {
            UserName = username;
            Password = password;
        }

    }
}