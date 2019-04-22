using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Helper;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class BookCategoryController : Controller
    {


        private readonly Book_Store_DbContext _context;

        public BookCategoryController(Book_Store_DbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var bookCategory = _context.BookCategories.ToList();
            return View(bookCategory);
        }


        public IActionResult Display(int id)
        {
            var book = _context.Books.Where(x => x.BookCategoryId == id);
            return View(book);
        }


    }
}














