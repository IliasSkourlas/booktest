using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBokk1.Models;
using Dapper;

namespace TestBokk1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Autherize(TestBokk1.Models.LoginAccount userModel)
        {
           
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserName", userModel.UserName);
            param.Add("@Password", userModel.Password);
            var userDetails= BookOneDB.ReturnList<LoginAccount>("sp_LoginMVC", param).FirstOrDefault<LoginAccount>();

            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Wrong User Name or Password";
                return View("Index", userModel); 
            }
            else
            {
                Session["userID"] = userDetails.LoginID;
                Session["userName"] = userDetails.UserName;

                return RedirectToAction("Index", "Home");
            }          
        }

        public ActionResult LogOut()
        {
            
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        


    }
}