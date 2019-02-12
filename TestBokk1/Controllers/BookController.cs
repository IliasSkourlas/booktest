using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBokk1.Models;

namespace TestBokk1.Controllers
{
    public class BookController : Controller
    {
        
        // GET: Book
        public ActionResult Index()
        {
            var db = new BookOneDB();

            var books = db.GetBooks();

            return View(books.ToList());
        }
    }
}