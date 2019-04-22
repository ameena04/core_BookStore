using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Helper;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class HomeController : Controller
    {
        private readonly Book_Store_DbContext _context;

        public HomeController(Book_Store_DbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          
            var books = _context.Books.ToList();
            int i = 0;
            int j = 0;
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    i++;
                }
                if (i != 0)
                {
                    foreach (var item in cart)
                    {
                        j++;
                    }
                }
                HttpContext.Session.SetString("CartItem", i.ToString());
            }
            return View(books);

        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search(string Search)
        {
            if (Search == null)
            {

                return RedirectToAction("Index", "Home");
            }

            //HttpContext.Session.SetString("Search", Search.ToString());

            var Book = _context.Books.Where(x => x.BookName == Search || x.BookCategory.BookCategoryName == Search 
            || x.Author.AuthorName == Search || x.Publication.PublicationName == Search || Search == null).ToList();
            return View(Book);
        }

    }
}