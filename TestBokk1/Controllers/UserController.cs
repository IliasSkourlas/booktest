using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBokk1.Models;

namespace TestBokk1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(BookOneDB.ReturnList<User>("sp_InfoUsers"));
              
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@LoginID", id);

                return View(BookOneDB.ReturnList<User>("sp_UserViewById", param).FirstOrDefault<User>());
            }

        }


        
        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@LoginID", user.LoginID);
            param.Add("@UserName", user.UserName);
            param.Add("@Password", user.Password);
            param.Add("@RoleType", user.RoleType);
            param.Add("@Clap", user.Clap);
            param.Add("@Carrier", user.Carrier);
            param.Add("@TL", user.TL);           
            BookOneDB.ExecuteWithoutReturn("sp_UserAddOrEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@LoginID", id);
            BookOneDB.ExecuteWithoutReturn("sp_DeleteUser", param);
            return RedirectToAction("Index");

        }
    }
}