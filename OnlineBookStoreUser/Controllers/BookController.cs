using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class BookController : Controller
    {
        private readonly Book_Store_DbContext _context;

        public BookController(Book_Store_DbContext context)
        {
            _context = context;
        }


       


        [Route("details/{id}")]
        public ActionResult Details(int id)
        {


            Books bk = _context.Books.Where(x => x.BookId == id).SingleOrDefault();
            _context.SaveChanges();
            ViewBag.reviews = _context.Reviews.Where(x => x.BookId == id).ToList();
            return View(bk);
        }


        [HttpGet]
        public ViewResult Review(int id)
        {
            HttpContext.Session.SetString("bookId", id.ToString());
            return View();
        }

        [HttpPost]
        public ActionResult Review(Reviews re)
        {
            if (HttpContext.Session.GetString("cid") != null || HttpContext.Session.GetString("bookId") != null)
            {
                re.CustomerId = Convert.ToInt32(HttpContext.Session.GetString("cid"));
                re.BookId = Convert.ToInt32(HttpContext.Session.GetString("bookId"));
            }
            _context.Reviews.Add(re);
            _context.SaveChanges();

            return RedirectToAction("Details", "Book", new { @id = re.BookId });
        }


      
    }
}