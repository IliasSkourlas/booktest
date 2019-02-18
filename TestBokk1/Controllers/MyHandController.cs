using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBokk1.Models;

namespace TestBokk1.Controllers
{
    public class MyHandController : Controller
    {
        public ActionResult Index()
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@CarrierLoginID", LoginAccount.MyID);
            return View(BookOneDB.ReturnList<Book>("sp_ViewBooksByCarrierLoginID", param));

        }
    }
}