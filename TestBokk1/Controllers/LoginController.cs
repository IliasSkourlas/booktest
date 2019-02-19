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
            
            return View("Index", "_myLayoutStartPage");
        }

        public ActionResult AboutStartUpPage()
        {
            ViewBag.Message = "Welcome. This is an app for searing your books with your friends. Not digital books, but your physical books. " +
                "It helps you to keep track with their whereabouts, as they are seared from a pool of carriers that you choose. " +
                "Read and write reviews and decide to give or not a Clap, when they are returned back to you in perfect condition. " +
                "So...explore and have fun...and don't hesitate searing!";


            return View("AboutStartUpPage", "_myLayoutStartPage");
        }

        public ActionResult ContactStartUpPage()
        {
            ViewBag.Message = "Uncertified Play Team - One";


            return View("ContactStartUpPage", "_myLayoutStartPage");
        }

        public ActionResult Autherize(TestBokk1.Models.LoginAccount userModel)
        {
           
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserName", userModel.UserName);
            param.Add("@Password", userModel.Password);

            var userDetails = BookOneDB.ReturnList<LoginAccount>("sp_LoginMVC", param).FirstOrDefault<LoginAccount>();

            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Wrong User Name or Password";
                return View("Index", userModel); 
            }
            else
            {
                Session["userID"] = userDetails.LoginID;
                Session["userName"] = userDetails.UserName;
                Session["roleType"] = userDetails.RoleType;
                LoginAccount.ThisRoleType = userDetails.RoleType;
                LoginAccount.MyID = userDetails.LoginID;

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
