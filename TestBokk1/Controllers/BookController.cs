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

        public ActionResult Index()
        {
            return View(BookOneDB.ReturnList<Book>("sp_GetInfoAllBooks"));
        }



        //        .. /Book/AddOrEdit  -insert
        //        .. /Book/AddOrEdit/id
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
               
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@BookID", id);

                return View(BookOneDB.ReturnList<Book>("sp_BookViewById",param).FirstOrDefault<Book>());
            }
            
        }



        [HttpPost]
        public ActionResult AddOrEdit(Book book)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BookID", book.BookID);
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
            BookOneDB.ExecuteWithoutReturn("sp_BookAddOrEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete (int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BookID", id);
            BookOneDB.ExecuteWithoutReturn("sp_DeleteFromBookByBookID", param);
            return RedirectToAction("Index");

        }
    }
}