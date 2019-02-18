using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestBokk1.Models
{
    public partial class LoginAccount
    {
        public int LoginID { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "This is required.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="This is required.")]
        public string Password { get; set; }

        public int RoleType { get; set; }

        public string LoginErrorMessage { get; set; }

        public static int MyID
        {
            get; set;
        }
        public static int ThisRoleType
        {
            get; set;
        }


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