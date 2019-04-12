using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class AuthorController : Controller
    {
        private readonly Book_Store_DbContext _context;

        public AuthorController(Book_Store_DbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            var author = _context.Authors.ToList();
            return View(author);
        }


        public IActionResult Display(int id)
        {
            var book = _context.Books.Where(x => x.AuthorId == id);
            return View(book);
        }

    }
}