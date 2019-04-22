using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class PublicationController : Controller
    {
        private readonly Book_Store_DbContext _context;

        public PublicationController(Book_Store_DbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var publication = _context.Publications.ToList();
            return View(publication);
        }


        public IActionResult Display(int id)
        {
            var book = _context.Books.Where(x => x.PublicationId == id);
            return View(book);
        }
    }
}