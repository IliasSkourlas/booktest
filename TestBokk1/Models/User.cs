using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBokk1.Models
{
    public class User
    {
        public string LoginID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleType { get; set; }
        public int Clap { get; set; }
        public int Carrier { get; set; }
        public string TL { get; set; }

        //public static int ThisRoleType
        //{
        //    get; set;
        //}


    }
}