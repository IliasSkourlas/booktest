using Dapper;
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
        //public ActionResult Index()
        //{
        //    var db = new BookOneDB();

        //    var books = db.GetBooks();

        //    return View(books.ToList());
        //}



        //public ActionResult Edit()
        //{
        //    var db = new BookOneDB();


        //    return View();
        //}


        public ActionResult Index()
        {
            return View(BookOneDB.ReturnList<Book>("sp_GetInfoAllBooks"));
        }



        //        .. /Employee/AddOrEdit  -insert
        //        .. /Employee/AddOrEdit/id
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddOrEdit(Book book)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", book.Title);
            param.Add("@Author",book.Author);
            param.Add("@DateOfLastMove",book.DateOfLastMove);
            param.Add("@Words",book.Words);
            param.Add("@OwnerLoginID",book.OwnerLoginID);
            param.Add("@CarrierLoginID",book.CarrierLoginID);
            param.Add("@BookStatus",book.BookStatus);
            param.Add("@Circulation",book.Circulation);
            param.Add("@Sent",book.Sent);
            param.Add("@Receive",book.Receive);
            BookOneDB.ExecuteWithoutReturn("sp_EnterBook", param);
            return RedirectToAction("Index");
        }

    }
}