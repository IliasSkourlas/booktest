using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBokk1.Models;

namespace TestBokk1.Controllers
{
    public class PoolBookController : Controller
    {
        // GET: PoolBook
        public ActionResult Index()
        {
            return View(BookOneDB.ReturnList<PoolBook>("sp_PoolBookView"));
        }
    }
}